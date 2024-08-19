using DAL.DbConnection;
using Data.DAL;
using Data.Repositories;
using DTO.LanguageDTO;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public class LanguageRepository : GenericRepository<Language>, ILanguageDAL
    {
        private readonly Context _db;
        public LanguageRepository(Context db)
        {
            _db = db;
        }

        public async Task<Language> GetById(Guid Id)
        {
            return await  _db.Languages.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<DataListDTO>> GetDataByLanguageKey(string culture)
        {
            IEnumerable<DataListDTO> data =await  _db.Languages.Where(x => x.Culture == culture).Select(x => new DataListDTO
            {
                Id=x.Id,
                Culture=x.Culture,
                ResourceKey=x.ResourceKey,
                ResourceValue=x.ResourceValue,

            }).ToListAsync();
           return data;
        }
    }
}
