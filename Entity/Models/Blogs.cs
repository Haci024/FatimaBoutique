using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Blogs
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool Status { get; set; }

        public List<BlogImages> BlogImages { get; set; }

       public int ViewCount { get; set; }

        public double Size { get; set; }

        public DateTime AddingDate { get; set; }

        public Categories Categories { get; set; }

        public int CategoryId { get; set; }


    }
}
