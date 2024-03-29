﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.DTOs
{
    public class TreniruoteDTO
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public DateTime SukurimoData { get; set; }
        public string SavaitesDiena { get; set; }
        public string SavaitesDienosSkaitineReiksme { get; set; }
        public string TreniruotesTipas { get; set; }
        public int? SportoProgramaId { get; set; }
        public ICollection<PratimasDTO> DaromiPratimai { get; set; }
    }

    public class CreateTreniruoteDTO
    {
        [Required]
        public string Pavadinimas { get; set; }
        [Required]
        public DateTime SukurimoData { get; set; }
        [Required]
        public string SavaitesDiena { get; set; }
        [Required]
        public string SavaitesDienosSkaitineReiksme { get; set; }
        [Required]
        public string TreniruotesTipas { get; set; }
        public int? SportoProgramaId { get; set; }
        public int? VartotojasId { get; set; }
    }

    public class UpdateTreniruoteDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Pavadinimas { get; set; }
        [Required]
        public DateTime SukurimoData { get; set; }
        [Required]
        public string SavaitesDiena { get; set; }
        [Required]
        public string SavaitesDienosSkaitineReiksme { get; set; }
        [Required]
        public string TreniruotesTipas { get; set; }
        public int? SportoProgramaId { get; set; }
        public int? VartotojasId { get; set; }
    }
}
