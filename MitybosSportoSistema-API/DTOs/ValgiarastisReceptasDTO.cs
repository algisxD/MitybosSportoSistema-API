﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.DTOs
{
    public class ValgiarastisReceptasDTO
    {
        public int Id { get; set; }
        public int ReceptasId { get; set; }
        public ReceptasDTO Receptas { get; set; }

        public int ValgiarastisId { get; set; }
        public ValgiarastisDTO Valgiarastis { get; set; }
    }

    public class CreateValgiarastisReceptasDTO
    {
        public int ReceptasId { get; set; }

        public int ValgiarastisId { get; set; }
    }
}
