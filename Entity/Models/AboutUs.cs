using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class AboutUs
    {
        public int Id { get; set; }

    }
    public class AboutUsLanguage
    {
        public int Id { get; set; }
        public Language Language { get; set; }

        public int LanguageId { get; set; }

        public AboutUs AboutUs { get; set; }

        public int AboutUsId { get; set; }

        public string FirstTitle { get; set; }
        public string SecondTitle { get; set; }
        public string Description { get; set; }




    }
}
