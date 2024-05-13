using DAL.DbConnection;
using Data.DAL;
using Data.Repositories;
using Entity.Models;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public class BlogImagesRepository:GenericRepository<BlogImages>,IBlogImagesDAL
    {
        private readonly Context _db;
        public BlogImagesRepository(Context db)
        {
            _db = db;
        }
        public string SelectFirstImageUrl(int blogId)
        {
            return _db.BlogsImages.Where(x => x.BLogId == blogId).Select(x => x.ImageUrl).FirstOrDefault();
        }
        public string SelectLastImageUrl(int blogId)
        {
            return _db.BlogsImages.Where(x => x.BLogId == blogId).Select(x => x.ImageUrl).LastOrDefault();
        }
    }
}
