using MitybosSportoSistema_API.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Models
{
    [Table("Receptai")]
    public class Receptas
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public string Nuotrauka { get; set; }
        public string Aprasymas { get; set; }
        public int GaminimoLaikas { get; set; }
        public int PorcijuSkaicius { get; set; }
        public int Kcal { get; set; }
        public virtual Vartotojas Vartotojas { get; set; }
        public int? VartotojasId { get; set; }
        public virtual ICollection<Ingridientas> Ingridientai { get; set; }
    }
}
