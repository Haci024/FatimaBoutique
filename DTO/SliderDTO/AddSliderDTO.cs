using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SliderDTO
{
    public class AddSliderDTO
    {
        public IFormFile SliderImage { get; set; }
        public string Url { get; set; }
        public bool Status { get; set; }
    }


}
