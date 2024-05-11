using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BlogsDTO
{
    public class UpdateBlogDTO
    {
        public decimal Price { get; set; }
        public bool SalesStatus { get; set; }
        public decimal SalesPrice { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        
    }
}
