using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class BlogImages
    {
        public int Id { get; set; }
        public string  ImageUrl { get; set; }
        public bool IsMain { get; set; }
        public bool Status { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public Blogs Blog { get; set; }
        public int BLogId { get; set; } 
    }
}
