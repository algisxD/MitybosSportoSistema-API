using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int? VartotojasId { get; set; }
        public Vartotojas Vartotojas { get; set; }
    }
}
