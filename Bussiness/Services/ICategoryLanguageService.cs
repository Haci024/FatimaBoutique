using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public interface ICategoryLanguageService:IGenericService<CategoryLanguage>
    {
        public IEnumerable<CategoryLanguage> ActiveMainCategoryList();
        public IEnumerable<CategoryLanguage> ActiveChildCategoryList();
        public IEnumerable<CategoryLanguage> DeactiveMainCategoryList();
        public IEnumerable<CategoryLanguage> DeactiveChildCategoryList();
        public IEnumerable<CategoryLanguage> ChildCategoryListByMain(int MainCategoryId);
    }
}
