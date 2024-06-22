using DAL.DbConnection;
using Data.DAL;
using Data.Repositories;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public class BLogsRepository : GenericRepository<Blogs>, IBlogDAL
    {
        private readonly Context _db;
        public async  Task<IEnumerable<Blogs>> BlogListWithCategory(int categoryId)
        {
            return await _db.Blogs.Include(x=>x.BlogLanguages).Include(x=>x.BlogLanguages).Include(x=>x.Categories).ThenInclude(x=>x.MainCategory).ToListAsync();
        }

        public async Task<IEnumerable<Blogs>> DeactiveBlogs()
        {
            return await _db.Blogs.Include(x=>x.BlogImages).Where(x=>x.Status==false).ToListAsync();
        }

        public async Task<IEnumerable<Blogs>> DiscountBlogs()
        {
            return await _db.Blogs.Include(x => x.BlogImages).Where(x => x.IsSales == true).ToListAsync();
        }

        public async  Task<IEnumerable<Blogs>> GetAllBlogs()
        {
            return await _db.Blogs.Include(x => x.BlogImages).Include(x => x.BlogLanguages).Include(x => x.Categories).ThenInclude(x => x.MainCategory).ToListAsync();
        }

        public async Task<IEnumerable<Blogs>> MostPopularBlogs()
        {
           return  await _db.Blogs.Include(x=>x.BlogImages).Include(x=>x.Categories).ThenInclude(x=>x.MainCategory).Include(x=>x.IsSales == true).ToListAsync();   
        }

   
    }
}
