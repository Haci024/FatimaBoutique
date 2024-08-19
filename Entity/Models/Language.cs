using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Language
    {
        public Guid Id { get; set; }
        public string Culture { get; set; }//AZ-az//TR-tr//RU-ru
        public string ResourceKey { get; set; }
        public string ResourceValue { get; set; }
    }
}
