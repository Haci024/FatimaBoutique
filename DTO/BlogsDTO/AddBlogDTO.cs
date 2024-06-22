using Entity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BlogsDTO
{
    public class AddBlogDTO
    {
        public decimal Price { get; set; }
        public bool SalesStatus { get; set; }
        public decimal SalesPrice { get; set; }
        public IEnumerable<CategoryLanguage> CategoryList { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public string Title_az { get; set; }
        public string Title_tr { get; set; }
        public string Title_en { get; set; }
        public string Title_ru { get; set; }
        public string Description_az { get; set; }
        public string Description_tr { get; set; }
        public string Description_en { get; set; }
        public string Description_ru { get; set; }
        public IFormFile[] Photos { get; set; }
    }

  
}
