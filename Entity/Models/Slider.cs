using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string ImageUrl{ get; set; }
        public string SavedImageUrl { get; set; }
        public string Url { get; set; }
        public bool Status { get; set; }      
    }
}
