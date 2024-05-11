using DAL.DAL;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public interface ICategoryLanguageDAL:IGenericDAL<CategoryLanguage>
    {
        public IEnumerable<CategoryLanguage> ActiveMainCategoryList();
        public IEnumerable<CategoryLanguage> ActiveChildCategoryList();
        public IEnumerable<CategoryLanguage> DeactiveMainCategoryList();
        public IEnumerable<CategoryLanguage> DeactiveChildCategoryList();
    }
}
