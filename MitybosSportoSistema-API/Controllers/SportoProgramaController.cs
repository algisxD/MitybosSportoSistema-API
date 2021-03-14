using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MitybosSportoSistema_API.Contracts;
using MitybosSportoSistema_API.DTOs;
using MitybosSportoSistema_API.Infrastructure.Repositories;
using MitybosSportoSistema_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Controllers
{
    /// <summary>
    /// Endpoint used to interact with the SportoPrograma in the SportoIrMitybos database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SportoProgramaController : ControllerBase
    {
        private readonly ISportoProgramaRepository _sportoProgramaRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public SportoProgramaController(ISportoProgramaRepository sportoProgramaRepository, ILoggerService logger, IMapper mapper)
        {
            _sportoProgramaRepository = sportoProgramaRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Get All SportoProgramos by userId");
                var sportoProgramos = await _sportoProgramaRepository.GetByUserId(userId);
                var response = _mapper.Map<ICollection<SportoProgramaDTO>>(sportoProgramos);
                _logger.LogInfo($"{location}:Successfully got all Receptai");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");

            }          
        }

        /// <summary>
        /// Update sport program status (active/inactive)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="programaDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] SportoProgramaUpdateActivityDTO sportProgramDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Update attempted - id: {id}");
                if (id < 1 || sportProgramDTO == null || id != sportProgramDTO.Id)
                {
                    _logger.LogWarn($"{location}: Update failed with bada data - id: {id}");
                    return BadRequest();
                }
                var isExists = await _sportoProgramaRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record - id: {id}");
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarn($"{location}: Data was incomplete");
                    return BadRequest(ModelState);
                }
                var sportProgram = _mapper.Map<SportoPrograma>(sportProgramDTO);
                var isSuccess = await _sportoProgramaRepository.Update(sportProgram);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Update operation failed with id: {id}");
                }
                _logger.LogWarn($"{location}: Record successfully updated id: {id}");
                return NoContent();
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates new sport program
        /// </summary>
        /// <param name="sportProgramDTO"></param>
        /// <returns>Sport program object</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateSportoProgramaDTO sportProgramDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Create attempted");
                if (sportProgramDTO == null)
                {
                    _logger.LogWarn($"{location}: Empty request was submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {

                    _logger.LogWarn($"{location}: Data was incomplete");
                    return BadRequest(ModelState);
                }
                var sportProgram = _mapper.Map<SportoPrograma>(sportProgramDTO);
                var isSucces = await _sportoProgramaRepository.Create(sportProgram);
                if (!isSucces)
                {
                    return InternalError($"{location}: creation failed");
                }
                _logger.LogInfo($"{location}: Creation was successful");
                return Created("Create", new { sportProgram });
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Gets sport program by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A sport program record</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSportProgram(int id)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call id: {id}");
                var sportProgram = await _sportoProgramaRepository.FindById(id);
                if (sportProgram == null)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record id: {id}");
                    return NotFound();
                }
                var response = _mapper.Map<SportoProgramaDTO>(sportProgram);
                _logger.LogInfo($"{location}: Successfully got record id: {id}");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Deletes sport program by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Delete attempted - id: {id}");
                if (id < 1)
                {
                    _logger.LogWarn($"{location}: Delete failed with bad data - id: {id}");
                    return BadRequest();
                }
                var isExists = await _sportoProgramaRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record - id:{id}");
                    return NotFound();
                }
                var sportProgram = await _sportoProgramaRepository.FindById(id);
                var isSuccess = await _sportoProgramaRepository.Delete(sportProgram);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Delete operation failed - id:{id}");
                }
                _logger.LogWarn($"{location}: Record successfully deleted id: {id}");
                return NoContent();
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
