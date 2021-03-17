using MitybosSportoSistema_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.DTOs
{
    public class ValgiarastisDTO
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public DateTime SukurimoData { get; set; }
        public string SavaitesDiena { get; set; }
        public int SavaitesDienosSkaitineReiksme { get; set; }
        public bool ArAktyvus { get; set; }
        public int? VartotojasId { get; set; }
        public ICollection<ReceptasDTO> Receptai { get; set; }
    }
}
