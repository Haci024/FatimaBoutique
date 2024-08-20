using DAL.DbConnection;
using Data.DAL;
using Data.Repositories;
using DTO.ProductImagesDTO;
using DTO.ProductsDTO;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public class ProductsRepository : GenericRepository<Products>, IProductDAL
    {
        private readonly Context _db;

        public ProductsRepository(Context db)
        {
            _db = db;
        }

        public async Task<IQueryable<FilterProductsListDTO>> FilterProducts()
        {
            var data = _db.Products.Include(x => x.Categories).Include(x => x.ProductsImages).Select(x => new FilterProductsListDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                SalesPrice = x.SalesPrice,
                SalesStatus = x.SalesStatus,
                Status = x.Status,
                DiscountPrice = x.DiscountPrice,
                ViewCount = x.ViewCount,
                CategoryName = x.Categories.Name,
                ProductsImages = x.ProductsImages.Select(y => new ImageListDTO
                {

                    Id = y.Id,
                    ImageUrl = y.ImageUrl,
                    SavedImageUrl = y.SavedImageUrl,
                    IsMain = y.IsMain,
                    Status = y.Status,
                    ProductId = y.ProductId,
                }).AsQueryable(),


            }).AsQueryable();

            return await  Task.FromResult(data);
        }

        public async Task<IEnumerable<ProductListDTO>> GetAllProducts()
        {
            var data = await _db.Products.Include(x=>x.Categories).Where(x=>x.Status==true  && x.Categories.Status==true).Select(x => new ProductListDTO
            {
                Id=x.Id,
                Name=x.Name,
                SalesPrice=x.SalesPrice,
                Status=x.Status,
                SalesStatus=x.SalesStatus,
                Price=x.Price,
                CategoryName=x.Categories.Name,
                CategoryId=x.CategoryId,
                SavedFileUrl=x.ProductsImages.First().SavedImageUrl,
                ImageUrl=x.ProductsImages.First().ImageUrl,
                Description=x.Description

            }).ToListAsync();

            return data; 
        }

        public async Task<IEnumerable<SearchProductDTO>> SearchProduct(string query)
        {
            var productsQuery =await  _db.Products.Include(x=>x.ProductsImages).Include(x=>x.Categories).Where(p => p.Name.Contains(query) || p.Categories.Name.Contains(query) && p.Status==true).Select(p=>new SearchProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                SalesPrice = p.SalesPrice,
                CategoryName = p.Categories.Name,
                SavedImageUrl = p.ProductsImages.FirstOrDefault().SavedImageUrl,
                ImageUrl = p.ProductsImages.FirstOrDefault().ImageUrl,
                Price = p.Price,
            }).ToListAsync();
            return  productsQuery;
        }
    }
}
