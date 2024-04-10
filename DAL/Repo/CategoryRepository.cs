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
    public class CategoryRepository:GenericRepository<Categories>,ICategoryDAL
    {
        private readonly Context _db;

        public CategoryRepository(Context db)
        {
            _db = db;
        }
        /// <summary>
        /// Aktiv kateqoriyaları əsas kateqoriyaları ilə birlikdə gətirir
        /// </summary>
        
        public List<Categories> ActiveCategoryList()
        {
            
            return _db.Categories.Include(x=>x.MainCategory).Where(x=>x.Status==false).ToList();
        }
        public List<Categories> categories=new List<Categories>();

        /// <summary>
        /// Deaktiv kateqoriyaları əsas kateqoriyaları ilə birlikdə gətirir
        /// </summary>

        public List<Categories> DeactiveCategoriesList()
        {
            return _db.Categories.Include(x=>x.MainCategory).Where(x=>x.Status==true).ToList();

        }
        /// <summary>
        /// Kateqoriyaya uyğun bloqları gətirir
        /// </summary>
        public List<Categories> GetBlogListByCategory(int Id)
        {
            return _db.Categories.Include(x=>x.MainCategory).Include(x=>x.Blogs).ThenInclude(x=>x.BlogImages).Where(x=>x.Id==Id).ToList();
        }
    }
}
