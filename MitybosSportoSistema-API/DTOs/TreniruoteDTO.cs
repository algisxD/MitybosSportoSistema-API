using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.DTOs
{
    public class TreniruoteDTO
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public int SavaitesDiena { get; set; }
        public string TreniruotesTipas { get; set; }
        public int? SportoProgramaId { get; set; }
        public List<PratimasDTO> DaromiPratimai { get; set; }
    }
}
