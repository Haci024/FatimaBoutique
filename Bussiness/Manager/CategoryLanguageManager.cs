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
    public class CategoryLanguageManager:ICategoryLanguageService
    {
        private readonly ICategoryLanguageDAL _dal;
        public CategoryLanguageManager(ICategoryLanguageDAL dal)
        {
            _dal = dal;
        }
        public void Create(CategoryLanguage t)
        {
            _dal.Create(t);
        }

        public void Delete(CategoryLanguage t)
        {
            _dal.Delete(t); 
        }

        public CategoryLanguage GetById(int id)
        {
            return _dal.GetById(id);
        }

        public IEnumerable<CategoryLanguage> GetList()
        {
            return _dal.GetList();
        }

        public void Update(CategoryLanguage t)
        {
            _dal.Update(t);
        }
    }
}
