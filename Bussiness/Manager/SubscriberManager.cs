using Bussiness.Services;
using Data.DAL;
using DTO.SubscriberDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Manager
{
    public class SubscriberManager : ISubscriberService
    {
        private readonly ISubscriberDAL _dal;
        public SubscriberManager(ISubscriberDAL dal)
        {
            _dal = dal;
        }
        public void Create(Subscribers t)
        {
            _dal.Create(t);
        }

        public void Delete(Subscribers t)
        {
            _dal.Delete(t);
        }

  

        public Subscribers GetById(int id)
        {
            return _dal.GetById(id);        
        }

        public IEnumerable<Subscribers> GetList()
        {
            return _dal.GetList();
        }

        public void Update(Subscribers t)
        {
            _dal.Update(t);
        }
    }
}
