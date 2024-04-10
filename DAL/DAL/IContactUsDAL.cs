﻿using DAL.DAL;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public interface IContactUsDAL:IGenericDAL<ContactUs>
    {
        public List<ContactUs> GetAllReadingMessages();

        public List<ContactUs> GetAllUnReadingMessages();
    }
}