using DAL.DbConnection;
using Data.DAL;
using Data.Repositories;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public class SubscriberRepository : GenericRepository<Subscribers>, ISubscriberDAL
    {
        private readonly Context _db;
        public SubscriberRepository(Context db)
        {
            _db = db;
        }
        public IEnumerable<Subscribers> ActiveSubscriberList()
        {
            return _db.Subscribers.Where(x => x.Status == true).ToList();
        }

        public IEnumerable<Subscribers> DeactiveSubscriberList()
        {
            return _db.Subscribers.Where(x=>x.Status==false).ToList();
        }

    
    }
}
