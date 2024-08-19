using DAL.DAL;
using DTO.LanguageDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public interface ILanguageDAL:IGenericDAL<Language>
    {
        Task<IEnumerable<DataListDTO>> GetDataByLanguageKey(string key);

        Task<Language> GetById(Guid Id);
    }
}
