using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CategoryDTO
{
    public class CategoryListDTO
    {
         public IEnumerable<CategoryLanguage> ActiveMainCategoryList { get; set; }

         public IEnumerable<CategoryLanguage> DeactiveMainCategoryList { get; set; }

        public IEnumerable<CategoryLanguage> ActiveChildCategoryList { get; set; }

        public IEnumerable<CategoryLanguage> DeactiveChildCategoryList { get; set; }

        public IEnumerable <CategoryLanguage> ChildCategoryListByMain { get; set; }

        public string MainCategoryName { get; set; }
    }
}
