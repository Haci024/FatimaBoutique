using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CustomerListDTO
{
    public class CustomerListDTO
    {
        public IEnumerable<AppUser> AdminList { get; set; }

        public IEnumerable<AppUser> CustomerList { get; set;}

        public IEnumerable<Subscribers> Subscribers { get; set;}
    }
}
