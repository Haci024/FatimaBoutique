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

        public int OrderId { get; set; }

        public Blogs Blogs { get; set; }

        public int  BlogId { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; }   


    }
}
