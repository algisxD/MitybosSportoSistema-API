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
    [Route("api/[controller]")]
    [ApiController]
    public class ValgiarastisReceptasController : ControllerBase
    {
        private readonly IValgiarastisReceptasRepository _valgiarastisReceptasRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public ValgiarastisReceptasController(IValgiarastisReceptasRepository valgiarastisRepository, ILoggerService logger, IMapper mapper)
        {
            _valgiarastisReceptasRepository = valgiarastisRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates new food menu
        /// </summary>
        /// <param name="foodMenuRecipeDTO"></param>
        /// <returns>Sport program object</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateValgiarastisReceptasDTO foodMenuRecipeDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Create attempted");
                if (foodMenuRecipeDTO == null)
                {
                    _logger.LogWarn($"{location}: Empty request was submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {

                    _logger.LogWarn($"{location}: Data was incomplete");
                    return BadRequest(ModelState);
                }
                var foodMenuRecipe = _mapper.Map<ValgiarastisReceptas>(foodMenuRecipeDTO);
                var isSucces = await _valgiarastisReceptasRepository.Create(foodMenuRecipe);
                if (!isSucces)
                {
                    return InternalError($"{location}: creation failed");
                }
                _logger.LogInfo($"{location}: Creation was successful");
                return Created("Create", new { foodMenuRecipe });
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Deletes recipe from food menu by id
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
                var isExists = await _valgiarastisReceptasRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record - id:{id}");
                    return NotFound();
                }
                var recipe = await _valgiarastisReceptasRepository.FindById(id);
                var isSuccess = await _valgiarastisReceptasRepository.Delete(recipe);
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
