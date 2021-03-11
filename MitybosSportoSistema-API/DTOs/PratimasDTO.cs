using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.DTOs
{
    public class PratimasDTO
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public string Aprasymas { get; set; }
        public int SerijuSkaicius { get; set; }
        public int PakartojimuSkaicius { get; set; }
    }
}
