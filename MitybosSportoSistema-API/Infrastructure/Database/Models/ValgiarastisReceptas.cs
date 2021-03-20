using MitybosSportoSistema_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Infrastructure.Database.Models
{
    public class ValgiarastisReceptas
    {
        public int Id { get; set; }
        public int ReceptasId { get; set; }
        public Receptas Receptas { get; set; }

        public int ValgiarastisId { get; set; }
        public Valgiarastis Valgiarastis { get; set; }
    }
}
