using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MitybosSportoSistema_API.Contracts;
using MitybosSportoSistema_API.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Controllers
{
    /// <summary>
    /// Endpoint used to interact with the exercises
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PratimasController : ControllerBase
    {
        private readonly IPratimasRepository _pratimasRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public PratimasController(IPratimasRepository pratimasRepository, ILoggerService logger, IMapper mapper)
        {
            _pratimasRepository = pratimasRepository;
            _logger = logger;
            _mapper = mapper;

        }


    }
}
