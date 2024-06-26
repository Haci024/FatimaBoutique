﻿using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public interface IContactUsService : IGenericService<ContactUs>
    {
        public IEnumerable<ContactUs> ReadMessageList();

        public IEnumerable<ContactUs> UnReadMessageList();
    }
}
