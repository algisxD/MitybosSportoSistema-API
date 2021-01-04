using AutoMapper;
using MitybosSportoSistema_API.Data;
using MitybosSportoSistema_API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Produktas, ProduktasDTO>().ReverseMap();
        }
    }
}
