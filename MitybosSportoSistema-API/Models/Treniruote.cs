using MitybosSportoSistema_API.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Models
{
    [Table("Treniruotes")]
    public class Treniruote
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public List<Pratimas> DaromiPratimai { get; set; } 
    }
}
