using DAL.DAL;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public interface ICategoryDAL:IGenericDAL<Categories>
    {
        public IEnumerable<Categories> ActiveCategoryList();

        public IEnumerable<Categories> DeactiveCategoriesList();

        public IEnumerable<Categories> GetBlogListByCategory(int Id);

        
    }
}
