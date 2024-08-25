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
    public class BasketManager:IBasketService
    {
        private readonly IBasketDAL _dal;
        public BasketManager(IBasketDAL dal)
        {
            _dal= dal;
        }

        public void Create(BasketItem t)
        {
            _dal.Create(t); 
        }

        public void Delete(BasketItem t)
        {
            _dal.Delete(t);
        }

        public BasketItem GetById(int id)
        {
            return _dal.GetById(id);
        }

        public IEnumerable<BasketItem> GetList()
        {
            return _dal.GetList();
        }

        public void Update(BasketItem t)
        {
            _dal.Update(t);
        }
    }
}
