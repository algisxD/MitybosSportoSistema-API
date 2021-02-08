using Microsoft.EntityFrameworkCore;
using MitybosSportoSistema_API.Contracts;
using MitybosSportoSistema_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Services
{
    public class ProduktasService : IProduktasRepository
    {
        private readonly ApplicationDbContext _db;

        public ProduktasService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IList<Produktas>> FindAll()
        {
            var produktai = await _db.Produktai.ToListAsync();
            return produktai;
        }

        public async Task<Produktas> FindById(int id)
        {
            var produktas = await _db.Produktai.FindAsync(id);
            return produktas;
        }
    }
}
