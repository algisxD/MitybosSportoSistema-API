﻿using Microsoft.EntityFrameworkCore;
using MitybosSportoSistema_API.Contracts;
using MitybosSportoSistema_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Services
{
    public class ProduktasRepository : IProduktasRepository
    {
        private readonly ApplicationDbContext _db;

        public ProduktasRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<Produktas>> FindAll()
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
