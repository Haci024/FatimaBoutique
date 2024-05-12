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
    public class BlogManager : IBlogService
    {
        private readonly IBlogDAL _dal;
        public BlogManager(IBlogDAL dal)
        {

            _dal = dal;

        }
        public void Create(Blogs t)
        {
            _dal.Create(t);
        }

        public void Delete(Blogs t)
        {
            _dal.Delete(t);
        }

        public Blogs GetById(int id)
        {
            return _dal.GetById(id);
        }

        public IEnumerable<Blogs> GetList()
        {
            return _dal.GetList();
        }

        public void Update(Blogs t)
        {
            _dal.Update(t);
        }
    }
}
