using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apelido { get; set; }
    }
}
