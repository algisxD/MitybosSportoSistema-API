using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MitybosSportoSistema_API.Models;

namespace MitybosSportoSistema_API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Pratimas> Pratimai { get; set; }
        public DbSet<Receptas> Receptai { get; set; }
        public DbSet<Treniruote> Treniruotes { get; set; }
        public DbSet<Produktas> Produktai { get; set; }
        public DbSet<Ingridientas> Ingridientai { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
