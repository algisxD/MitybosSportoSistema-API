using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.DTOs
{
    public class ProduktasDTO
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public double Kcal { get; set; }
        public double Vanduo { get; set; }
        public double Baltymai { get; set; }
        public double Angliavandeniai { get; set; }
        public double Riebalai { get; set; }
        public double Druska { get; set; }
    }
}
