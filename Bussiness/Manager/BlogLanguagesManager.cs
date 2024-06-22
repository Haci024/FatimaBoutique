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
    public class BlogLanguagesManager : IBlogLanguagesService
    {
        private readonly IBlogLanguagesDAL _dal;
        public BlogLanguagesManager(IBlogLanguagesDAL dal)
        {
            _dal = dal;
        }
        public async Task<IEnumerable<BlogsLanguage>> ProductListWithCategory(int categoryId)
        {
            return await  _dal.ProductListWithCategory(categoryId);
        }

        public void Create(BlogsLanguage t)
        {
            _dal.Create(t);
        }

        public  async Task<IEnumerable<BlogsLanguage>> DeactiveProducts()
        {
            return await  _dal.DeactiveProducts();
        }

        public void Delete(BlogsLanguage t)
        {
            _dal.Delete(t);
        }

        public async Task<IEnumerable<BlogsLanguage>> DiscountProducts()
        {
            return  await _dal.DiscountProducts();
        }

        public async Task<IEnumerable<BlogsLanguage>> GetAllProducts()
        {
           return await _dal.GetAllProducts();
        }

        public BlogsLanguage GetById(int id)
        {
            return _dal.GetById(id);
        }

        public  IEnumerable<BlogsLanguage> GetList()
        {
            return  _dal.GetList();
        }

        public async Task<IEnumerable<BlogsLanguage>> MostPopularProducts()
        {
           return  await  _dal.MostPopularProducts();
        }

        public void Update(BlogsLanguage t)
        {
            _dal.Update(t);
        }
    }
}
