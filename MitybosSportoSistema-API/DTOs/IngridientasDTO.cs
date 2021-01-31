using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.DTOs
{
    public class IngridientasDTO
    {
        public int Id { get; set; }
        public int Kiekis { get; set; }
        public virtual ProduktasDTO Produktas { get; set; }
    }
}
