using MitybosSportoSistema_API.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Models
{
    [Table("Ingridientai")]
    public class Ingridientas
    {
        public int Id { get; set; }
        public double Kiekis { get; set; }
        public virtual Produktas Produktas { get; set; }
    }
}
