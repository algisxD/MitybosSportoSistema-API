using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.DTOs
{
    public class VartotojasDTO
    {
    }

    public class VartotojasRecipeGetDTO
    {
        public string Vardas { get; set; }
    }
    public class NewVartotojasDTO
    {
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public int Ugis { get; set; }
        public int Svoris { get; set; }
    }
}
