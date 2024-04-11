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
    public class VideoRepository : GenericRepository<Videos>, IVideoDAL
    {
        private readonly Context _db;
        public VideoRepository(Context db)
        {
            _db = db;
        }
        public List<Videos> DeactiveVideoList()
        {
         return _db.Videos.Where(x=>x.Status==true).ToList();
        }

        public List<Videos> GetActiveVideoList()
        {
            return _db.Videos.Where(x=>x.Status==false).ToList();
        }
    }
}
