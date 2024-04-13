using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ContactUsDTO
{
    public class ContactMessageListDTO
    {
        public List<ContactUs> UnReadMessages { get; set; }

        public List<ContactUs> ReadMessages { get; set; }


    }
}
