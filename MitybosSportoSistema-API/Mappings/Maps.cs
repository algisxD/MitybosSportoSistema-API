using AutoMapper;
using MitybosSportoSistema_API.Data;
using MitybosSportoSistema_API.DTOs;
using MitybosSportoSistema_API.Infrastructure.Database.Models;
using MitybosSportoSistema_API.Models;
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
            CreateMap<Receptas, ReceptasDTO>().ReverseMap();
            CreateMap<Produktas, ProduktasDTO>().ReverseMap();
            CreateMap<Ingridientas, IngridientasDTO>().ReverseMap();           
            CreateMap<Receptas, ReceptasCreateDTO>().ReverseMap();           
            CreateMap<Ingridientas, IngridientasCreateDTO>().ReverseMap();           
            CreateMap<Vartotojas, VartotojasRecipeGetDTO>().ReverseMap();           
            CreateMap<Vartotojas, VartotojasDTO>().ReverseMap();           
            CreateMap<Vartotojas, NewVartotojasDTO>().ReverseMap();           
            CreateMap<Pratimas, PratimasDTO>().ReverseMap();           
            CreateMap<Pratimas, CreatePratimasDTO>().ReverseMap();           
            CreateMap<Pratimas, UpdatePratimasDTO>().ReverseMap();           
            CreateMap<Treniruote, TreniruoteDTO>().ReverseMap();           
            CreateMap<Treniruote, CreateTreniruoteDTO>().ReverseMap();           
            CreateMap<Treniruote, UpdateTreniruoteDTO>().ReverseMap();           
            CreateMap<SportoPrograma, SportoProgramaDTO>().ReverseMap();           
            CreateMap<SportoPrograma, CreateSportoProgramaDTO>().ReverseMap();           
            CreateMap<SportoPrograma, SportoProgramaUpdateActivityDTO>().ReverseMap();           
            CreateMap<Valgiarastis, ValgiarastisDTO>().ReverseMap();           
            CreateMap<Valgiarastis, UpdateValgiarastisDTO>().ReverseMap();           
            CreateMap<Valgiarastis, CreateValgiarastisDTO>().ReverseMap();           
            CreateMap<ValgiarastisReceptas, ValgiarastisReceptasDTO>().ReverseMap();           
            CreateMap<ValgiarastisReceptas, CreateValgiarastisReceptasDTO>().ReverseMap();           
        }
    }
}
