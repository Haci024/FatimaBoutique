using DTO.ProductsDTO;
using Entity.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public interface IProductService:IGenericService<Products>
    {
        Task<IEnumerable<ProductListDTO>> AllProducts();
        Task<IQueryable<FilterProductsListDTO>> FilterProductList();
        Task<IQueryable<SearchProductDTO>> SearchProduct(string query);


    }
}
