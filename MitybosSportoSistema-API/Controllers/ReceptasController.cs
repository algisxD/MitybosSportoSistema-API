using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MitybosSportoSistema_API.Contracts;
using MitybosSportoSistema_API.DTOs;
using MitybosSportoSistema_API.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MitybosSportoSistema_API.Controllers
{
    /// <summary>
    /// Endpoint used to interact with the Receptas in the SportoIrMitybos database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class ReceptasController : ControllerBase
    {
        private readonly IReceptasRepository _receptasRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public ReceptasController(IReceptasRepository receptasRepository, ILoggerService logger, IMapper mapper)
        {
            _receptasRepository = receptasRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all receptai
        /// </summary>
        /// <returns>List of authors</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReceptai()
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Get All Receptai");
                var receptai = await _receptasRepository.FindAll();
                var response = _mapper.Map<ICollection<ReceptasDTO>>(receptai);
                _logger.LogInfo($"{location}:Successfully got all Receptai");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");

            }
        }

        /// <summary>
        /// Gets a recipe by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A recipe record</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRecipe(int id)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call id: {id}");
                var recipe = await _receptasRepository.FindById(id);
                if (recipe == null)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record id: {id}");
                    return NotFound();
                }
                var response = _mapper.Map<ReceptasDTO>(recipe);
                _logger.LogInfo($"{location}: Successfully got record id: {id}");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates a new recipe
        /// </summary>
        /// <param name="recipeDTO"></param>
        /// <returns>Recipe object</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ReceptasCreateDTO recipeDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Create attempted");
                if (recipeDTO == null)
                {
                    _logger.LogWarn($"{location}: Empty request was submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {

                    _logger.LogWarn($"{location}: Data was incomplete");
                    return BadRequest(ModelState);
                }
                var recipe = _mapper.Map<Receptas>(recipeDTO);
                var isSucces = await _receptasRepository.Create(recipe);
                if (!isSucces)
                {
                    return InternalError($"{location}: creation failed");
                }
                _logger.LogInfo($"{location}: Creation was successful");
                return Created("Create", new { recipe });
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Uploads dishes picture
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("upload")]
        public async Task<IActionResult> PostFileUpload()
        {
            var location = GetControllerActionNames();
            try
            {
                var file = HttpContext.Request.Form.Files["image"];
                MemoryStream msFile = new MemoryStream();
                await file.CopyToAsync(msFile);

                var ext = Path.GetExtension(file.FileName);
                var picId = Guid.NewGuid().ToString().Replace("-", "");
                var picName = $"{picId}{ext}";

                string projectPath = Directory.GetCurrentDirectory();
                var path = $"{projectPath}\\sportomitybossistema-ui\\src\\assets\\uploads\\{picName}";

                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    msFile.WriteTo(fs);
                }

                return Ok(picName);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }

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
