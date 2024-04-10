using DAL.DAL;
using DAL.DbConnection;
using Data.DAL;
using Data.Repositories;
using Entity.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public class ContactUsRepository : GenericRepository<ContactUs>, IContactUsDAL
    {
        private readonly Context _db;

        public ContactUsRepository(Context db)
        {
            _db = db;
        }

        public List<ContactUs> GetAllReadingMessages()
        {
            return _db.ContactUs.Where(x => x.Viewed == true).ToList();
        }

        public List<ContactUs> GetAllUnReadingMessages()
        {
           return _db.ContactUs.Where(x=>x.Viewed==false).ToList();
        }
    }
}
