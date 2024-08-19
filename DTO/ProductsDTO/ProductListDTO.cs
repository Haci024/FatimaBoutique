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
    public class ProductListDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public bool SalesStatus { get; set; }
        public decimal SalesPrice { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string SavedFileUrl { get; set; }

    }
}
