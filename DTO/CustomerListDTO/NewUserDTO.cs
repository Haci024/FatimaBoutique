using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CustomerListDTO
{
    public class NewUserDTO
    {
        public string FullName { get; set; }

        public string Email { get; set; }   

        public string RoleId { get; set; }

       
    }
}
