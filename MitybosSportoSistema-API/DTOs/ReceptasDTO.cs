using MitybosSportoSistema_API.Models;
using System;
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
        public bool ArViesas { get; set; }
        public int Kcal { get; set; }
        public virtual VartotojasRecipeGetDTO ReceptoAutorius { get; set; }
        public virtual ICollection<IngridientasDTO> Ingridientai { get; set; }
    }

    public class UpdateReceptasDTO
    {
        [Required]
        public int Id { get; set; }
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
        public bool ArViesas { get; set; }
        [Required]
        public int? VartotojasId { get; set; }
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
        public int? VartotojasId { get; set; }
        [Required]
        public virtual ICollection<IngridientasCreateDTO> Ingridientai { get; set; }
    }
}
