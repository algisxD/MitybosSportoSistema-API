using Microsoft.EntityFrameworkCore;
using MitybosSportoSistema_API.Data;
using MitybosSportoSistema_API.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Infrastructure.Repositories
{
    public class ValgiarastisReceptasRepository : IValgiarastisReceptasRepository
    {
        private readonly ApplicationDbContext _db;

        public ValgiarastisReceptasRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(ValgiarastisReceptas entity)
        {
            await _db.ValgiarasciaiReceptai.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(ValgiarastisReceptas entity)
        {
            _db.ValgiarasciaiReceptai.Remove(entity);
            return await Save();
        }

        public Task<ICollection<ValgiarastisReceptas>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ValgiarastisReceptas> FindById(int id)
        {
            var valgiarastisReceptas = await _db.ValgiarasciaiReceptai
                .Include(o => o.Receptas)
                .Include(q => q.Valgiarastis)
                .FirstOrDefaultAsync(q => q.Id == id);
            return valgiarastisReceptas;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.ValgiarasciaiReceptai.AnyAsync(q => q.Id == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public Task<bool> Update(ValgiarastisReceptas entity)
        {
            throw new NotImplementedException();
        }
    }
}
