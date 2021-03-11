using Microsoft.EntityFrameworkCore;
using MitybosSportoSistema_API.Data;
using MitybosSportoSistema_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Infrastructure.Repositories
{
    public class PratimasRepository : IPratimasRepository
    {
        private readonly ApplicationDbContext _db;

        public PratimasRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Pratimas entity)
        {
            await _db.Pratimai.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Pratimas entity)
        {
            _db.Pratimai.Remove(entity);
            return await Save();
        }

        public Task<ICollection<Pratimas>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Pratimas> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.Pratimai.AnyAsync(q => q.Id == id);
            return isExists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Pratimas entity)
        {
            _db.Pratimai.Update(entity);
            return await Save();
        }
    }
}
