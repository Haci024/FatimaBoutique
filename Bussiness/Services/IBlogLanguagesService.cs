using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public interface IBlogLanguagesService:IGenericService<BlogsLanguage>
    {
        Task<IEnumerable<BlogsLanguage>> GetAllProducts();

        Task<IEnumerable<BlogsLanguage>> ProductListWithCategory(int categoryId);

        Task<IEnumerable<BlogsLanguage>> DeactiveProducts();

        Task<IEnumerable<BlogsLanguage>> DiscountProducts();

        Task<IEnumerable<BlogsLanguage>> MostPopularProducts();
    }
}
