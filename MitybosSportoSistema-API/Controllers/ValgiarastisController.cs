using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MitybosSportoSistema_API.Contracts;
using MitybosSportoSistema_API.DTOs;
using MitybosSportoSistema_API.Infrastructure.Database.Models;
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

        /// <summary>
        /// Gets a food menu by id
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
                var foodMenu = await _valgiarastisRepository.FindById(id);
                if (foodMenu == null)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record id: {id}");
                    return NotFound();
                }
                var response = _mapper.Map<ValgiarastisDTO>(foodMenu);
                _logger.LogInfo($"{location}: Successfully got record id: {id}");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Update food menu status (active/inactive)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="programaDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateValgiarastisDTO foodMenuDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Update attempted - id: {id}");
                if (id < 1 || foodMenuDTO == null || id != foodMenuDTO.Id)
                {
                    _logger.LogWarn($"{location}: Update failed with bada data - id: {id}");
                    return BadRequest();
                }
                var isExists = await _valgiarastisRepository.isExists(id);
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
                var foodMenu = _mapper.Map<Valgiarastis>(foodMenuDTO);
                var isSuccess = await _valgiarastisRepository.Update(foodMenu);
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
        /// Creates new food menu
        /// </summary>
        /// <param name="foodMenuDTO"></param>
        /// <returns>Sport program object</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateValgiarastisDTO foodMenuDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Create attempted");
                if (foodMenuDTO == null)
                {
                    _logger.LogWarn($"{location}: Empty request was submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {

                    _logger.LogWarn($"{location}: Data was incomplete");
                    return BadRequest(ModelState);
                }
                var foodMenu = _mapper.Map<Valgiarastis>(foodMenuDTO);
                var isSucces = await _valgiarastisRepository.Create(foodMenu);
                if (!isSucces)
                {
                    return InternalError($"{location}: creation failed");
                }
                _logger.LogInfo($"{location}: Creation was successful");
                return Created("Create", new { foodMenu });
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Gets active food menus by user id and todays date
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("user/{userId}/{day}")]
        public async Task<IActionResult> Get(int userId, int day)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Get All work outs by userId and todays date");
                var foodMenu = await _valgiarastisRepository.FindByIdAndTodaysDate(userId, day);
                var response = _mapper.Map<ICollection<ValgiarastisDTO>>(foodMenu);
                _logger.LogInfo($"{location}:Successfully got all Treniruotes");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");

            }
        }

        /// <summary>
        /// Deletes food menu by id
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
                var isExists = await _valgiarastisRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record - id:{id}");
                    return NotFound();
                }
                var foodMenu = await _valgiarastisRepository.FindById(id);
                var isSuccess = await _valgiarastisRepository.Delete(foodMenu);
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
