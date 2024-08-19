using DAL.DAL;
using DTO.CategoryDTO.Child;
using DTO.CategoryDTO.Main;
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
         Task<IEnumerable<MainCategoryListDTO>> ActiveMainCategoryList();

         Task<IEnumerable<ChildCategoryListDTO>> ActiveChildCategoryList();

         Task<IEnumerable<ChildCategoryListDTO>> DeactiveChildCategoryList();

         IEnumerable<NavbarCategoryListDTO> NavbarCategoryList();

        Task<IEnumerable<ChildCategoryListDTO>> ChildCategoryListByMain(int mainCategoryId);

    }
}
