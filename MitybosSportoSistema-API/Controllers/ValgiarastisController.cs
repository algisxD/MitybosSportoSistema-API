using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MitybosSportoSistema_API.Contracts;
using MitybosSportoSistema_API.DTOs;
using MitybosSportoSistema_API.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Controllers
{
    /// <summary>
    /// Endpoint used to interact with the Valgiarasciai table in the SportoIrMitybos database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValgiarastisController : ControllerBase
    {
        private readonly IValgiarastisRepository _valgiarastisRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public ValgiarastisController(IValgiarastisRepository valgiarastisRepository, ILoggerService logger, IMapper mapper)
        {
            _valgiarastisRepository = valgiarastisRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets users menu by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Get All Valgiarasciai by userId");
                var menu = await _valgiarastisRepository.GetByUserId(userId);
                var response = _mapper.Map<ICollection<ValgiarastisDTO>>(menu);
                _logger.LogInfo($"{location}:Successfully got all Valgiarasciai");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");

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
