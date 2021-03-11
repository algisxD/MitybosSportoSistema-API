using MitybosSportoSistema_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Models
{
    [Table("SportoPrograma")]
    public class SportoPrograma
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public DateTime SukurimoData { get; set; }
        public bool ArAktyvi { get; set; }
        public virtual Vartotojas Vartotojas { get; set; }
        public int? VartotojasId { get; set; }
        public List<Treniruote> Treniruotes { get; set; }
    }
}
