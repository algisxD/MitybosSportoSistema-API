using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Models
{
    [Table("Vartotojai")]
    public class Vartotojas
    {
        public int Id { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public int Ugis { get; set; }
        public int Svoris { get; set; }
        public ICollection<Receptas> Receptai { get; set; }
        public ICollection<SportoPrograma> SportoProgramos { get; set; }
    }
}
