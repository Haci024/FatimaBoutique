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
    public class OrderManager : IOrdersService
    {
        private readonly IOrderDAL _dal;
        public OrderManager(IOrderDAL dal)
        {
            _dal = dal;
        }

        public void Create(Orders t)
        {
           _dal.Create(t);
        }

        public void Delete(Orders t)
        {
            _dal.Delete(t);
        }

        public Orders GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Orders> GetList()
        {
            return _dal.GetList();
        }

        public void Update(Orders t)
        {
            _dal.Update(t);
        }
    }
}
