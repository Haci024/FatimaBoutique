using DTO.LanguageDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public interface ILanguagesService:IGenericService<Language>
    {
        Task<IEnumerable<DataListDTO>> GetDataByLanguageKey(string culture);

        Task<Language> GetByGuidId(Guid Id);
    }
}
