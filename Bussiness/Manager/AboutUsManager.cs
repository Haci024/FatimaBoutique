using Bussiness.Services;
using Data.DAL;
using Entity.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Manager
{
    public class AboutUsManager:IAboutUsService
    {
        private readonly IAboutUsDAL _dal;
        
        public AboutUsManager(IAboutUsDAL dal)
        {
            _dal = dal;
        }

        public void Create(AboutUs t)
        {
            _dal.Create(t);
        }

        public void Delete(AboutUs t)
        {
            _dal.Delete(t);
        }

        public AboutUs GetById(int id)
        {
           return _dal.GetById(id);
        }

        public List<AboutUs> GetList()
        {
            return _dal.GetList();
        }

        public void Update(AboutUs t)
        {
             _dal.Update(t);
        }
    }
}
