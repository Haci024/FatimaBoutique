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
    public class BlogImagesManager : IBlogImagesService
    {
        private readonly IBlogImagesDAL _dal;
        public BlogImagesManager(IBlogImagesDAL dal)
        {
            _dal= dal;
        }
        public void Create(BlogImages t)
        {
            _dal.Create(t);
        }

        public void Delete(BlogImages t)
        {
            _dal.Delete(t);
        }

        public BlogImages GetById(int id)
        {
            return _dal.GetById(id);
        }

        public IEnumerable<BlogImages> GetList()
        {
            return _dal.GetList();
        }

        public void Update(BlogImages t)
        {
            _dal.Update(t);
        }
    }
}
