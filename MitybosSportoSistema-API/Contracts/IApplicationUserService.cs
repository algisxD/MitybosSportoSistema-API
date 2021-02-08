using MitybosSportoSistema_API.DTOs;
using MitybosSportoSistema_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Contracts
{
    public interface IApplicationUserService
    {
        Task<ApplicationUser> Create(Vartotojas newUser, NewVartotojasDTO newUserDTO);
    }
}
