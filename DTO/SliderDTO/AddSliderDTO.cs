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
        public IFormFile Photo { get; set; }
        public decimal Percent { get; set; }
        public bool Status { get; set; }
        public DateTime AddingDate { get; set; }
        public List<AddSliderLanguageDTO> Languages { get; set; }
    }

    public class AddSliderLanguageDTO
    {
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
