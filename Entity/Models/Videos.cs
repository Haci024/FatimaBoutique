using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Videos
    {
        public int Id { get; set; } 

        public string Title { get; set; }

        public string VideoUrl { get; set; }

        public bool Status { get; set; }

        public DateTime AddingDate { get; set; }
    }
}
