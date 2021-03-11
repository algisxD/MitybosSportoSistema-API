using MitybosSportoSistema_API.Data;
using Microsoft.EntityFrameworkCore;
using MitybosSportoSistema_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Infrastructure.Repositories
{
    public class SportoProgramaRepository : ISportoProgramaRepository
    {
        private readonly ApplicationDbContext _db;

        public SportoProgramaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(SportoPrograma entity)
        {
            await _db.SportoProgramos.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(SportoPrograma entity)
        {
            _db.SportoProgramos.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<SportoPrograma>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<SportoPrograma> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<SportoPrograma>> GetByUserId(int userId)
        {
            var sportoProgramos = _db.SportoProgramos.Where( i => i.VartotojasId == userId)
                .Include(o => o.Treniruotes)
                .ThenInclude(p => p.DaromiPratimai);
            return await sportoProgramos.ToListAsync();
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(SportoPrograma entity)
        {
            _db.SportoProgramos.Update(entity);
            return await Save();
        }
        public async Task<bool> isExists(int id)
        {
            return await _db.SportoProgramos.AnyAsync(q => q.Id == id);
        }

    }
}
