using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Models
{
    [Table("Pratimai")]
    public class Pratimas
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public string Aprasymas { get; set; }
        public int SerijuSkaicius { get; set; }
        public int PakartojimuSkaicius { get; set; }
    }
}
