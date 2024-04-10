using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public interface ICategoryService:IGenericService<Categories>
    {
        public List<Categories> ActiveCategoryList();

        public List<Categories> DeactiveCategoriesList();

        public List<Categories> GetBlogListByCategory(int Id);
    }
}
