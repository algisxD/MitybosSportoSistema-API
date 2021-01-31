using Microsoft.EntityFrameworkCore;
using MitybosSportoSistema_API.Contracts;
using MitybosSportoSistema_API.Data;
using MitybosSportoSistema_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Services
{
    public class ReceptasRepository : IReceptasRepository
    {
        private readonly ApplicationDbContext _db;

        public ReceptasRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Receptas entity)
        {
            await _db.Receptai.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Receptas entity)
        {
            _db.Receptai.Remove(entity);
            return await Save();
        }

        public async Task<IList<Receptas>> FindAll()
        {
            var recipes = await _db.Receptai
                .Include(q => q.Ingridientai)
                .ThenInclude(i => i.Produktas)
                .ToListAsync();
            return recipes;
        }

        public async Task<Receptas> FindById(int id)
        {
            var receptas = await _db.Receptai
                .Include(q => q.Ingridientai)
                .ThenInclude(i => i.Produktas)
                .FirstOrDefaultAsync(q => q.Id == id); ;
            return receptas;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.Receptai.AnyAsync(q => q.Id == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Receptas entity)
        {
            _db.Receptai.Update(entity);
            return await Save();
        }
    }
}
