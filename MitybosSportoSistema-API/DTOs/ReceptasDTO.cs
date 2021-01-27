using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.DTOs
{
    public class ReceptasDTO
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public string Nuotrauka { get; set; }
        public string Aprasymas { get; set; }
        public int GaminimoLaikas { get; set; }
        public int PorcijuSkaicius { get; set; }
        public virtual IList<IngridientasDTO> Ingridientai { get; set; }
    }
}
