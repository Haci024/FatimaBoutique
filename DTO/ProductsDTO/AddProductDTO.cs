using DTO.CategoryDTO.Child;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ProductsDTO
{
    public class AddProductDTO
    {
        public int Id { get; set; } 
        public decimal Price { get; set; }
        public bool SalesStatus { get; set; }
        public decimal SalesPrice { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<ChildCategoryListDTO> ChildCategories { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastDateForIsSale { get; set; }
        public IFormFile[] Photos { get; set; }
    }

  
}
