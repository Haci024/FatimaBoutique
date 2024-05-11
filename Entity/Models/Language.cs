using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public List<BlogsLanguage> BlogLanguages { get; set; }
        public List<CategoryLanguage> CategoryLanguages{ get; set; }
        public List<OrderLanguage> OrderLanguages { get; set; } 
        
    }
}
