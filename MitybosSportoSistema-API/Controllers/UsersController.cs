using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MitybosSportoSistema_API.Contracts;
using MitybosSportoSistema_API.DTOs;

namespace MitybosSportoSistema_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILoggerService _logger;
        private readonly IConfiguration _config;

        public UsersController(SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager,
            ILoggerService logger, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _config = config;
        }

        /// <summary>
        /// Get user info endpoint
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserInfo()
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Get user info attempted");
                //Sutvarkyt logus sudeliot try catch bei istaisyti headerius
                var identity = HttpContext.User.Identity as ClaimsIdentity;

                // Gets list of claims.
                IEnumerable<Claim> claim = identity.Claims;
                if (claim.Count() != 0)
                {

                    // Gets name from claims. Generally it's an email address.
                    var usernameClaim = claim
                        .Where(x => x.Type == ClaimTypes.NameIdentifier)
                        .FirstOrDefault();

                    var user = await _userManager
                        .FindByNameAsync(usernameClaim.Value);
                    var role = await _userManager
                        .GetRolesAsync(user);

                    _logger.LogInfo($"{location}: {user} Successfully got user info");
                    return Ok(new { email = user.UserName, roles = role });
                }
                else
                {
                    _logger.LogInfo($"{location}: Failed to get user info");
                    return BadRequest();
                }
                    
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }  
        }


        /// <summary>
        /// User login endpoint
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                var username = userDTO.Email;
                var password = userDTO.Password;
                _logger.LogInfo($"{location}: Login attempt from User: {username}");
                var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

                if (result.Succeeded)
                {
                    _logger.LogInfo($"{location}: {username} Successfully Authenticated");
                    var user = await _userManager.FindByEmailAsync(username);
                    var tokenString = await GenerateJSONWebToken(user);
                    return Ok(new { token = tokenString }) ;
                }
                _logger.LogInfo($"{location}: {username} Not Authenticated: ");
                return Unauthorized(userDTO);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        private async Task<string> GenerateJSONWebToken(IdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)

            };
            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim(ClaimsIdentity.DefaultRoleClaimType, r)));

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                null,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GetControllerActionNames()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }

        private ObjectResult InternalError(string message)
        {
            _logger.LogError(message);
            return StatusCode(500, "Something went wrong. Please contact the Administrator");
        }
    }
}
