using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Basket
    {
        public int Id { get; set; }

        public Orders Orders { get; set; }

        public int OrdersId { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; }   

    }
}
