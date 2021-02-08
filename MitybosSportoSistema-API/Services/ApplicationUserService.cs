using MitybosSportoSistema_API.Contracts;
using MitybosSportoSistema_API.DTOs;
using MitybosSportoSistema_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        public Task<ApplicationUser> Create(Vartotojas newUser, NewVartotojasDTO newUserDTO)
        {
            throw new NotImplementedException();
        }
    }
}
