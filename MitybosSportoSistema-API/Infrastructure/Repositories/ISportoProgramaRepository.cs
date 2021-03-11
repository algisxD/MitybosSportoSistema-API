using MitybosSportoSistema_API.Contracts;
using MitybosSportoSistema_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Infrastructure.Repositories
{
    public interface ISportoProgramaRepository : IRepositoryBase<SportoPrograma>
    {
        Task<ICollection<SportoPrograma>> GetByUserId(int userId);
    }
}
