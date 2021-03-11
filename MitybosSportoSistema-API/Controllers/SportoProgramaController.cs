﻿using AutoMapper;
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
        public async Task<IActionResult> Update(int id, [FromBody] SportoProgramaUpdateActivityDTO programaDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Update attempted - id: {id}");
                if (id < 1 || programaDTO == null || id != programaDTO.Id)
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
                var programa = _mapper.Map<SportoPrograma>(programaDTO);
                var isSuccess = await _sportoProgramaRepository.Update(programa);
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