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
        public List<Categories> ActiveCategoryList();

        public List<Categories> DeactiveCategoriesList();

        public List<Categories> GetBlogListByCategory(int Id);

        
    }
}
