using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class ContactUs
    {
        public int Id { get; set; } 

        public string FullName { get; set; }
        
        public string Gmail { get; set; }

        public string PhoneNumber { get;set; }

        public string Title { get; set; }

        public string Description { get; set; }
        /// <summary>
        /// Bu hissədə admin gələn mesajlara adminpaneldən baxanda status true olan kimi oxunanlar səhifəsinə transfer olacaq.
        /// </summary>
        public bool Viewed { get; set; } = false;


       
    }
}
