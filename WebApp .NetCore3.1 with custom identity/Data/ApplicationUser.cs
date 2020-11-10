using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_.NetCore3._1_with_custom_identity.Data
{
    public class ApplicationUser:IdentityUser
    {
        public int Age { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
    }
}
