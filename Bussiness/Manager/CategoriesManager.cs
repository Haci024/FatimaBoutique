using Bussiness.Services;
using Data.DAL;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Manager
{
    public class CategoriesManager:ICategoryService
    {
        private readonly ICategoryDAL _dal;

        public CategoriesManager(ICategoryDAL dal)
        {
            _dal = dal;
        }

        public IEnumerable<Categories> ActiveCategoryList()
        {
            return _dal.ActiveCategoryList();
        }

        public void Create(Categories t)
        {
           _dal.Create(t);
        }

        public IEnumerable<Categories> DeactiveCategoriesList()
        {
            return _dal.DeactiveCategoriesList();
        }

        public void Delete(Categories t)
        {
           _dal.Delete(t);
        }

        public IEnumerable<Categories> GetBlogListByCategory(int categoryId)
        {
            return _dal.GetBlogListByCategory(categoryId);
        }

        public Categories GetById(int id)
        {
            return _dal.GetById(id);
        }

        public IEnumerable<Categories> GetList()
        {
            return _dal.GetList();
        }

        public void Update(Categories t)
        {
             _dal.Update(t);
        }
    }
}
