using MitybosSportoSistema_API.Data;
using MitybosSportoSistema_API.Infrastructure.Enums;
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
        public DateTime SukurimoData { get; set; }
        public string TreniruotesTipas { get; set; }
        public string SavaitesDiena { get; set; }
        public int SavaitesDienosSkaitineReiksme { get; set; }
        public int? SportoProgramaId { get; set; }
        public int? VartotojasId { get; set; }
        public List<Pratimas> DaromiPratimai { get; set; } 
    }
}
