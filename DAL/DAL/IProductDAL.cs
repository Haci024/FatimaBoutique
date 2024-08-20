using DAL.DAL;
using DTO.ProductsDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public interface IProductDAL:IGenericDAL<Products>
    {
        Task<IEnumerable<ProductListDTO>> GetAllProducts();

        Task<IQueryable<FilterProductsListDTO>> FilterProducts();

        Task<IEnumerable<SearchProductDTO>> SearchProduct(string query);
    }
}
