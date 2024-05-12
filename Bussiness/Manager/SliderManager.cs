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
    public class SLiderManager:ISliderService
    {
        private readonly ISliderDAL _dal;
        public SLiderManager(ISliderDAL dal)
        {
            _dal = dal;
        }

        public void Create(Slider t)
        {
            _dal.Create(t);
        }

        public void Delete(Slider t)
        {
            _dal.Delete(t);
        }

        public Slider GetById(int id)
        {
            return _dal.GetById(id);    
        }

        public IEnumerable<Slider> GetList()
        {
            return _dal.GetList();
        }

        public void Update(Slider t)
        {
            _dal.Update(t);
        }
    }
}
