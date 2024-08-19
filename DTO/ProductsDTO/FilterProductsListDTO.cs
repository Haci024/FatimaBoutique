using DTO.ProductImagesDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ProductsDTO
{
    public class FilterProductsListDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
      
        public bool SalesStatus { get; set; }
        public decimal SalesPrice { get; set; }
        public bool IsSales { get; set; } = false;
        public decimal DiscountPrice { get; set; }
        public bool Status { get; set; }
        public IQueryable<ImageListDTO> ProductsImages { get; set; }
        public int ViewCount { get; set; }
        public string CategoryName { get; set; }
        public DateTime AddingDate { get; set; }

        public DateTime LastDateForIsSale { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
