using MitybosSportoSistema_API.Data;
using MitybosSportoSistema_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MitybosSportoSistema_API.Infrastructure.Repositories
{
    public class TreniruoteRepository : ITreniruoteRepository
    {
        private readonly ApplicationDbContext _db;

        public TreniruoteRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Treniruote entity)
        {
            await _db.Treniruotes.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Treniruote entity)
        {
            _db.Treniruotes.Remove(entity);
            return await Save();
        }

        public Task<ICollection<Treniruote>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Treniruote> FindById(int id)
        {
            var workOut = await _db.Treniruotes
                .Include(q => q.DaromiPratimai)
                .FirstOrDefaultAsync(q => q.Id == id);
            return workOut;
        }

        public async Task<ICollection<Treniruote>> FindByIdAndTodaysDate(int id, int dayOfTheWeek)
        {
            var workOut = await _db.Treniruotes
                .Where(u => u.VartotojasId == id && u.SavaitesDienosSkaitineReiksme == dayOfTheWeek)
                .Include(q => q.DaromiPratimai)
                .ToListAsync();
            return workOut;
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.Treniruotes.AnyAsync(q => q.Id == id);
            return isExists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Treniruote entity)
        {
            _db.Treniruotes.Update(entity);
            return await Save();
        }
    }
}
