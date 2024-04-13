using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserDTO
{
    public class ResetPasswordDTO
    {
        public string Password { get; set; }    

        public string ConfirmPassword { get; set; }
    }
}
