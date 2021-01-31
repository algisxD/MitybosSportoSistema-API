﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.DTOs
{
    public class ReceptasDTO
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public string Nuotrauka { get; set; }
        public string Aprasymas { get; set; }
        public int GaminimoLaikas { get; set; }
        public int PorcijuSkaicius { get; set; }
        public virtual IList<IngridientasDTO> Ingridientai { get; set; }
    }
    public class ReceptasCreateDTO
    {
        [Required]
        public string Pavadinimas { get; set; }
        [Required]
        public string Nuotrauka { get; set; }
        [Required]
        public string Aprasymas { get; set; }
        [Required]
        public int GaminimoLaikas { get; set; }
        [Required]
        public int PorcijuSkaicius { get; set; }
        [Required]
        public virtual IList<IngridientasCreateDTO> Ingridientai { get; set; }
    }
}