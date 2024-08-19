using Bussiness.Services;
using Data.DAL;
using DTO.CategoryDTO.Child;
using DTO.CategoryDTO.Main;
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

   

        public async Task<IEnumerable<ChildCategoryListDTO>> ActiveChildCategoryList()
        {
            return await _dal.ActiveChildCategoryList();
        }

        public async Task<IEnumerable<MainCategoryListDTO>> ActiveMainCategoryList()
        {
            return await _dal.ActiveMainCategoryList();
        }

        public async Task<IEnumerable<ChildCategoryListDTO>> ChildCategoryListByMain(int mainCategoryId)
        {
            return await _dal.ChildCategoryListByMain(mainCategoryId);
        }

        public void Create(Categories t)
        {
           _dal.Create(t);
        }

       

        public async Task<IEnumerable<ChildCategoryListDTO>> DeactiveChildCategoryList()
        {
            return await _dal.DeactiveChildCategoryList();
        }

        public void Delete(Categories t)
        {
           _dal.Delete(t);
        }
        public Categories GetById(int id)
        {
            return _dal.GetById(id);
        }
        public IEnumerable<Categories> GetList()
        {
            return _dal.GetList();
        }

        public IEnumerable<NavbarCategoryListDTO> NavbarCategoryList()
        {
            return _dal.NavbarCategoryList();
        }

        public void Update(Categories t)
        {
             _dal.Update(t);
        }
    }
}
