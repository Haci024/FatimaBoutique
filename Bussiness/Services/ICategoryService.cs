using DTO.CategoryDTO.Child;
using DTO.CategoryDTO.Main;
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
         IEnumerable<NavbarCategoryListDTO> NavbarCategoryList();

        Task<IEnumerable<MainCategoryListDTO>> ActiveMainCategoryList();

        Task<IEnumerable<ChildCategoryListDTO>> ActiveChildCategoryList();

        Task<IEnumerable<ChildCategoryListDTO>> DeactiveChildCategoryList();

        Task<IEnumerable<ChildCategoryListDTO>> ChildCategoryListByMain(int mainCategoryId);
    }
}
