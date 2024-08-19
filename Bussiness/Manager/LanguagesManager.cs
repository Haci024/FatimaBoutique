using Bussiness.Services;
using DAL.DbConnection;
using Data.DAL;
using DTO.LanguageDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Manager
{
    public class LanguagesManager : ILanguagesService
    {
        private readonly Context _db;
        private readonly ILanguageDAL _dal;
       
        public LanguagesManager(Context db,ILanguageDAL dal)
        {
         
            _db = db;
          _dal = dal;
        }

        public void Create(Language t)
        {
            _dal.Create(t);
        }

        public void Delete(Language t)
        {
            _dal.Delete(t);
        }

        public Task<Language> GetByGuidId(Guid Id)
        {
            return _dal.GetById(Id);
        }

        public Language GetById(int id)
        {
            return _dal.GetById(id);
        }

        public async Task<IEnumerable<DataListDTO>> GetDataByLanguageKey(string culture)
        {
            return await  _dal.GetDataByLanguageKey(culture);
        }

        public IEnumerable<Language> GetList()
        {
            return _dal.GetList();
        }

        public string GetResource(string culture, string key)
        {
            var resource = _db.Languages.FirstOrDefault(r => r.Culture == culture && r.ResourceKey == key);

            return resource?.ResourceValue ?? key;
        }

        public void Update(Language t)
        {
            _dal.Update(t);
        }
    }
}
