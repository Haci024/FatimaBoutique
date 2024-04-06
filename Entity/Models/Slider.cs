using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Slider
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImagelUrl { get; set; }

        public IFormFile Photo { get; set; }
        
        public decimal Percent { get;set; }

        public string Description { get; set; }

        public bool Status { get; set; }    


    }
}
