using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.DTOs
{
    public class SportoProgramaUpdateActivityDTO
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public DateTime SukurimoData { get; set; }
        public bool ArAktyvi { get; set; }
        public int? VartotojasId { get; set; }
    }
}
