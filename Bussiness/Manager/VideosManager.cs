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
    public class VideosManager : IVideoService
    {
        private readonly IVideoDAL _dal;
        public VideosManager(IVideoDAL dal)
        {
            _dal= dal;
        }
        public void Create(Videos t)
        {
            _dal.Create(t); 
        }

        public void Delete(Videos t)
        {
            _dal.Delete(t);
        }

        public Videos GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Videos> GetList()
        {
            return _dal.GetList();
        }

        public void Update(Videos t)
        {
            _dal.Update(t);
        }
    }
}
