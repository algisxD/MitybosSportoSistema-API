using MitybosSportoSistema_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Contracts
{
    public interface IReceptasRepository : IRepositoryBase<Receptas>
    {
        Task<ICollection<Receptas>> FindAllPublicRecipes();
        Task<ICollection<Receptas>> GetByUserId(int userId);
        Task<ICollection<Receptas>> GetByFoodMenuId(int foodMenuId);
    }
}
