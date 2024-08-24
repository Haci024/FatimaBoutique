using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class AppUser:IdentityUser
    {
        public bool Status { get; set; }
        
        public int ForgetPasswordCode { get; set; } = 000000;

        public string PhoneNumber { get; set; }

        public int ConfirmationCode { get; set; }

        public bool ActivateBonus { get; set; }

    }
}
