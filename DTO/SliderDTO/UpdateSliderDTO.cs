using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SliderDTO
{
    public class UpdateSliderDTO
    {
        public IFormFile Photo { get; set; }
        public bool Status { get; set; }
        public string url { get; set; }
       
    }
}
    