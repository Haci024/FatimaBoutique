using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LanguageDTO
{
    public class UpdateDataDTO
    {
        public Guid Id { get; set; }
        public string Culture { get; set; }
        public string ResourceKey { get; set; }
        public string ResourceValue { get; set; }
    }
}
