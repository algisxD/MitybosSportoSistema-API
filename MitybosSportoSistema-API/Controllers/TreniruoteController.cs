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
    /// Interacts with the Treniruote tab;e
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TreniruoteController : ControllerBase
    {
        private readonly ITreniruoteRepository _treniruoteRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public TreniruoteController(ITreniruoteRepository trenitruoteRepository, ILoggerService logger, IMapper mapper)
        {
            _treniruoteRepository = trenitruoteRepository;
            _logger = logger;
            _mapper = mapper;

        }


        /// <summary>
        /// Creates a new workout
        /// </summary>
        /// <param name="treniruoteDTO"></param>
        /// <returns>Workout object</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateTreniruoteDTO workOutDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Create attempted");
                if (workOutDTO == null)
                {
                    _logger.LogWarn($"{location}: Empty request was submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {

                    _logger.LogWarn($"{location}: Data was incomplete");
                    return BadRequest(ModelState);
                }
                var workOut = _mapper.Map<Treniruote>(workOutDTO);
                var isSucces = await _treniruoteRepository.Create(workOut);
                if (!isSucces)
                {
                    return InternalError($"{location}: creation failed");
                }
                _logger.LogInfo($"{location}: Creation was successful");
                return Created("Create", new { workOut });
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Gets a workout by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A workout record</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTreniruote(int id)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call id: {id}");
                var workOut = await _treniruoteRepository.FindById(id);
                if (workOut == null)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record id: {id}");
                    return NotFound();
                }
                var response = _mapper.Map<TreniruoteDTO>(workOut);
                _logger.LogInfo($"{location}: Successfully got record id: {id}");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Deletes a treniruote by id
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
                var isExists = await _treniruoteRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record - id:{id}");
                    return NotFound();
                }
                var treniruote = await _treniruoteRepository.FindById(id);
                var isSuccess = await _treniruoteRepository.Delete(treniruote);
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

        /// <summary>
        /// Updates a workout
        /// </summary>
        /// <param name="id"></param>
        /// <param name="workOutDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTreniruoteDTO workOutDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Update attempted - id: {id}");
                if (id < 1 || workOutDTO == null || id != workOutDTO.Id)
                {
                    _logger.LogWarn($"{location}: Update failed with bada data - id: {id}");
                    return BadRequest();
                }
                var isExists = await _treniruoteRepository.isExists(id);
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
                var workOut = _mapper.Map<Treniruote>(workOutDTO);
                var isSuccess = await _treniruoteRepository.Update(workOut);
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
