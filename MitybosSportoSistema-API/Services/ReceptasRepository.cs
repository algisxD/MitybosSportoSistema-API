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
            var authors = await _db.Receptai
                .Include(q => q.Ingridientai)
                .ToListAsync();
            return authors;
        }

        public async Task<Receptas> FindById(int id)
        {
            var author = await _db.Receptai
                .Include(q => q.Ingridientai)
                .FirstOrDefaultAsync(q => q.Id == id); ;
            return author;
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
