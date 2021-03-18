using MitybosSportoSistema_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Infrastructure.Database.Models
{
    [Table("Valgiarasciai")]
    public class Valgiarastis
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public DateTime SukurimoData { get; set; }
        public string SavaitesDiena { get; set; }
        public int SavaitesDienosSkaitineReiksme { get; set; }
        public bool ArAktyvus { get; set; }
        public int? VartotojasId { get; set; }
        public ICollection<ValgiarastisReceptas> ValgiarastisReceptas { get; set; }
    }
}
