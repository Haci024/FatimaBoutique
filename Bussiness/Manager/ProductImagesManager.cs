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
    public class ProductImagesManager : IProductImageService
    {
        private readonly IProductImagesDAL _dal;
        public ProductImagesManager(IProductImagesDAL dal)
        {
            _dal= dal;
        }
        public void Create(ProductsImages t)
        {
            _dal.Create(t);
        }

        public void Delete(ProductsImages t)
        {
            _dal.Delete(t);
        }

        public ProductsImages GetById(int id)
        {
            return _dal.GetById(id);
        }

        public IEnumerable<ProductsImages> GetList()
        {
            return _dal.GetList();
        }

        public void Update(ProductsImages t)
        {
            _dal.Update(t);
        }
    }
}
