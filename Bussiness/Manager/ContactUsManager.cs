using Bussiness.Services;
using Data.DAL;
using Entity.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Manager
{
    public class ContactUsManager:IContactUsService
    {
        private readonly IContactUsDAL _dal;
        public ContactUsManager(IContactUsDAL dal)
        {
            _dal = dal;
        }

        public void Create(ContactUs t)
        {
           _dal.Create(t);
        }

        public void Delete(ContactUs t)
        {
            _dal.Delete(t);
        }

        public ContactUs GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<ContactUs> GetList()
        {
            return _dal.GetList();
        }

        public List<ContactUs> ReadMessageList()
        {
            return _dal.GetAllReadingMessages();
        }

        public List<ContactUs> UnReadMessageList()
        {
            return _dal.GetAllUnReadingMessages();
        }

        public void Update(ContactUs t)
        {
            _dal.Update(t);
        }
    }
}
