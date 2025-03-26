﻿using Microsoft.AspNetCore.Identity;

namespace Identity.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apelido { get; set; }
    }
}
