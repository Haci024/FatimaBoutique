using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AboutUsDTO
{
    public class UpdateAboutUsDTO
    {
        public List<UpdateAboutUsLanguageDTO> Languages { get; set; }
    }

    public class UpdateAboutUsLanguageDTO
    {
        public int LanguageId { get; set; }
        public string FirstTitle { get; set; }
        public string SecondTitle { get; set; }
        public string Description { get; set; }
    }
}
