using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MitybosSportoSistema_API.Contracts;
using MitybosSportoSistema_API.DTOs;

namespace MitybosSportoSistema_API.Controllers
{
    /// <summary>
    /// Endpoint used to interact with the Authors in the book store's database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class ProduktasController : ControllerBase
    {
        private readonly IProduktasRepository _produktaiRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public ProduktasController(IProduktasRepository produktaiRepository, ILoggerService logger, IMapper mapper)
        {
            _produktaiRepository = produktaiRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Produktai
        /// </summary>
        /// <returns>List of Produktai</returns>
        [HttpGet]
        public async Task<IActionResult> GetProduktai()
        {
            try
            {
                _logger.LogInfo("Attempted Get All Recipes");
                var produktai = await _produktaiRepository.FindAll();
                var response = _mapper.Map<IList<ProduktasDTO>>(produktai);
                _logger.LogInfo("Successfully got all Recipes");
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message} - {e.InnerException}");
                return StatusCode(500, "Something went wrong. Please contact the Administrator");
            }
        }
    }
}
