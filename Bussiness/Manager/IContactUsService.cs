using Bussiness.Services;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Manager
{
    public interface IContactUsService:IGenericService<ContactUs>
    {
        public List<ContactUs> ReadMessageList();

        public List<ContactUs> UnReadMessageList();

      
    }
}
