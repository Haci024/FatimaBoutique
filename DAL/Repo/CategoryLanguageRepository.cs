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
    public class CategoryLanguageRepository:GenericRepository<CategoryLanguage>,ICategoryLanguageDAL
    {
        private readonly Context _db;
        public CategoryLanguageRepository(Context db)
        {
            _db = db;
        }
        public IEnumerable<CategoryLanguage> ActiveMainCategoryList()
        {

            return _db.CategoryLanguages.Include(x=>x.Language).Include(x=>x.Categories).Where(x=>x.CategoryId==null && x.Categories.Status==false  && x.Language.Key=="az").ToList();
        }
        public IEnumerable<CategoryLanguage> ActiveChildCategoryList()
        {

            return _db.CategoryLanguages.Include(x => x.Language).Include(x => x.Categories).Where(x => x.CategoryId != null && x.Categories.Status == false && x.Language.Key == "az").ToList();
        }
        public IEnumerable<CategoryLanguage> DeactiveMainCategoryList()
        {

            return _db.CategoryLanguages.Include(x => x.Language).Include(x => x.Categories).Where(x => x.CategoryId == null && x.Categories.Status == true && x.Language.Key == "az").ToList();
        }
        public IEnumerable<CategoryLanguage> DeactiveChildCategoryList()
        {

            return _db.CategoryLanguages.Include(x => x.Language).Include(x => x.Categories).Where(x => x.CategoryId != null && x.Categories.Status == true && x.Language.Key == "az").ToList();
        }
    }
}
