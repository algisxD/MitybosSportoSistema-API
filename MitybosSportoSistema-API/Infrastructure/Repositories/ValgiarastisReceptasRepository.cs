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

        public Task<bool> Delete(ValgiarastisReceptas entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ValgiarastisReceptas>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<ValgiarastisReceptas> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isExists(int id)
        {
            throw new NotImplementedException();
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
