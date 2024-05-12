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

        public void Create(Basket t)
        {
            _dal.Create(t); 
        }

        public void Delete(Basket t)
        {
            _dal.Delete(t);
        }

        public Basket GetById(int id)
        {
            return _dal.GetById(id);
        }

        public IEnumerable<Basket> GetList()
        {
            return _dal.GetList();
        }

        public void Update(Basket t)
        {
            _dal.Update(t);
        }
    }
}
