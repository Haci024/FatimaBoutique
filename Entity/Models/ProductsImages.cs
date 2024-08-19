using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class ProductsImages
    {
        public int Id { get; set; }
        public string  ImageUrl { get; set; }
        public string SavedImageUrl { get; set; }
        public bool IsMain { get; set; }
        public bool Status { get; set; }
        public Products Products { get; set; }
        public int ProductId { get; set; } 
    }
}
