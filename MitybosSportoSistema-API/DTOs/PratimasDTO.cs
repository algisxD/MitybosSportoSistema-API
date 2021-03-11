using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int? TreniruoteId { get; set; }
    }

    public class CreatePratimasDTO
    {
        [Required]
        public string Pavadinimas { get; set; }
        [Required]
        public string Aprasymas { get; set; }
        [Required]
        public int SerijuSkaicius { get; set; }
        [Required]
        public int PakartojimuSkaicius { get; set; }
        public int? TreniruoteId { get; set; }
    }

    public class UpdatePratimasDTO
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public string Aprasymas { get; set; }
        public int SerijuSkaicius { get; set; }
        public int PakartojimuSkaicius { get; set; }
        public int? TreniruoteId { get; set; }
    }
}
