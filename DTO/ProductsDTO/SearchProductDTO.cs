using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ProductsDTO
{
    public class SearchProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public  string  ImageUrl { get; set; }

        public string SavedImageUrl { get; set; }

        public decimal Price { get; set; }

        public decimal SalesPrice { get; set; }

        public string CategoryName { get; set; }    
    }
}
