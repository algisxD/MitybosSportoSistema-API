using MitybosSportoSistema_API.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MitybosSportoSistema_API.Data
{
    [Table("Produktai")]
    public class Produktas
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public double Kcal { get; set; }
        public double Vanduo { get; set; }
        public double Baltymai { get; set; }
        public double Angliavandeniai { get; set; }
        public double Riebalai { get; set; }
        public double Druska { get; set; }
        public List<Ingridientas> Ingridientai { get; set; }
    }
}