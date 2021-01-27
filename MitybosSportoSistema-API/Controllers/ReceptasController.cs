using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MitybosSportoSistema_API.Contracts;

namespace MitybosSportoSistema_API.Controllers
{
    /// <summary>
    /// Endpoint used to interact with the Receptas in the SportoIrMitybos database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
