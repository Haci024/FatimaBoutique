using DAL.DbConnection;
using Data.DAL;
using Data.Repositories;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public class BlogLanguagesRepository : GenericRepository<BlogsLanguage>, IBlogLanguagesDAL
    {
        private readonly Context _db;
        public BlogLanguagesRepository(Context db)
        {
            _db = db;
        }
        public async Task<IEnumerable<BlogsLanguage>> ProductListWithCategory(int categoryId)
        {
            return await _db.BlogsLanguages.Include(x => x.Language).Include(x => x.Blogs).ThenInclude(x => x.Categories).ThenInclude(x=>x.MainCategory).Where(x=>x.Blogs.CategoryId==categoryId && x.Blogs.Status==true).ToListAsync();
        }
        public async Task<IEnumerable<BlogsLanguage>> DeactiveProducts()
        {
            return await _db.BlogsLanguages.Include(x => x.Language).Include(x => x.Blogs).ThenInclude(x => x.Categories).Where(x=>x.Blogs.Status==false).ToListAsync();
        }
        public async Task<IEnumerable<BlogsLanguage>> DiscountProducts()
        {
            return await _db.BlogsLanguages.Include(x => x.Language).Include(x => x.Blogs).ThenInclude(x => x.Categories).Where(x=>x.Blogs.SalesStatus==true && x.Blogs.Status==true).ToListAsync();
        }

        public async Task<IEnumerable<BlogsLanguage>> GetAllProducts()
        {
            return await _db.BlogsLanguages.Include(x => x.Language).Include(x => x.Blogs).ThenInclude(x => x.Categories).Where(x=>x.Blogs.Status==true).ToListAsync();
        }

        public async Task<IEnumerable<BlogsLanguage>> MostPopularProducts()
        {
            return await _db.BlogsLanguages.Include(x => x.Language).Include(x => x.Blogs).ThenInclude(x => x.Categories).OrderByDescending(x=>x.Blogs.ViewCount).Take(3).ToListAsync();

        }
    }
}
