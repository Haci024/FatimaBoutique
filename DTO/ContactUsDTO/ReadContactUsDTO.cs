using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ContactUsDTO
{
    public class ReadContactUsDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Gmail { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public bool Status { get; set; }    


    }
}
