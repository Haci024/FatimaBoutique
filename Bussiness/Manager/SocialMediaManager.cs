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
    public class SocialMediaManager:ISocialMediaService
    {
        private readonly ISocialMediaDAL _dal;
        public SocialMediaManager(ISocialMediaDAL dal)
        {
            _dal= dal;
        }

        public void Create(SocialMedia t)
        {
            throw new NotImplementedException();
        }

        public void Delete(SocialMedia t)
        {
            throw new NotImplementedException();
        }

        public SocialMedia GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<SocialMedia> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(SocialMedia t)
        {
            throw new NotImplementedException();
        }
    }
}
