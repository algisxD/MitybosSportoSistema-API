using Microsoft.EntityFrameworkCore;
using MitybosSportoSistema_API.Data;
using MitybosSportoSistema_API.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Infrastructure.Repositories
{
    public class ValgiarastisRepository : IValgiarastisRepository
    {
        private readonly ApplicationDbContext _db;

        public ValgiarastisRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Valgiarastis entity)
        {
            await _db.Valgiarasciai.AddAsync(entity);
            return await Save();
        }

        public async Task<ICollection<Valgiarastis>> FindByIdAndTodaysDate(int id, int dayOfTheWeek)
        {
            var foodMenu = await _db.Valgiarasciai
                .Include(q => q.ValgiarastisReceptas)
                .ThenInclude(r => r.Receptas)
                .ThenInclude(i => i.Ingridientai)
                .Where(u => u.VartotojasId == id && u.SavaitesDienosSkaitineReiksme == dayOfTheWeek && u.ArAktyvus == true)
                .ToListAsync();
            return foodMenu;
        }

        public async Task<bool> Delete(Valgiarastis entity)
        {
            _db.Valgiarasciai.Remove(entity);
            return await Save();
        }

        public Task<ICollection<Valgiarastis>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Valgiarastis> FindById(int id)
        {
            var menu = await _db.Valgiarasciai
                .Include(o => o.ValgiarastisReceptas)
                .ThenInclude(q => q.Receptas)
                .FirstOrDefaultAsync(q => q.Id == id);
            return menu;        }

        public async Task<ICollection<Valgiarastis>> GetByUserId(int userId)
        {
            var menu = _db.Valgiarasciai.Where(i => i.VartotojasId == userId)
                .Include(o => o.ValgiarastisReceptas)
                .ThenInclude(q => q.Receptas);
            return await menu.ToListAsync();
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.Valgiarasciai.AnyAsync(q => q.Id == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Valgiarastis entity)
        {
            _db.Valgiarasciai.Update(entity);
            return await Save();
        }
    }
}
