﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.DTOs
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserGetDTO
    {
        public string Email { get; set; }
    }
}
