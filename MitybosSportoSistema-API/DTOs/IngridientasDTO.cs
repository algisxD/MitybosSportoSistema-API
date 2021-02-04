using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class IngridientasCreateDTO
    {
        [Required]
        public int Kiekis { get; set; }
        [Required]
        public int? ProduktasId { get; set; }
    }
}
