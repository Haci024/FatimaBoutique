using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class AppUser:IdentityUser<string>
    {
       
        public string Gmail {  get; set; }

        public string FullName { get; set; }

        public bool Status { get; set; }    


    }
}
