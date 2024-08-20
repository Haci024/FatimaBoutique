using Business.Services;
using Bussiness.Services;
using Data.DAL;
using DTO.ProductImagesDTO;
using DTO.ProductsDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Manager
{
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _dal;
        private readonly IGoogleCloudStorageService _service;
        public ProductManager(IProductDAL dal,IGoogleCloudStorageService cloud)
        {

            _dal = dal;
            _service = cloud;

        }

        public async Task<IEnumerable<ProductListDTO>> AllProducts()
        {
            var products=await _dal.GetAllProducts();
            foreach (var product in products)
            {
               await  GenerateSignedUrl(product);
            }
            return products;

        }
        private async Task GenerateSignedUrl(ProductListDTO dto)
        {

            if (!string.IsNullOrWhiteSpace(dto.ImageUrl))
            {
                dto.ImageUrl = await _service.GetSignedUrl(dto.SavedFileUrl);
            }
        }
        public void Create(Products t)
        {
            _dal.Create(t);
        }

      
        public void Delete(Products t)
        {
            _dal.Delete(t);
        }


        public Products GetById(int id)
        {
            return _dal.GetById(id);
        }

        public IEnumerable<Products> GetList()
        {
            return _dal.GetList();
        }

     
        public void Update(Products t)
        {
            _dal.Update(t);
        }

        public  async Task<IQueryable<FilterProductsListDTO>> FilterProductList()
        {
            IQueryable<FilterProductsListDTO> products =await _dal.FilterProducts();
            foreach (var product in products)
            {
                GenerateSignedUrl(product.ProductsImages);
            }
            return products;
        }
        private async Task GenerateSignedUrl(IQueryable<ImageListDTO> dto)
        {
            foreach (var item in dto)
            {
                if (!string.IsNullOrWhiteSpace(item.ImageUrl))
                {
                    item.ImageUrl = await _service.GetSignedUrl(item.SavedImageUrl);
                }
            }
          
        }

        public async Task<IQueryable<SearchProductDTO>> SearchProduct(string query)
        {
            IQueryable<SearchProductDTO> products=await _dal.SearchProduct(query);
            foreach (var item in products)
            {

                GenerateSignedUrlForFilter(item);
            }
            return  products;
        }
        private async Task GenerateSignedUrlForFilter(SearchProductDTO dto)
        {
          
                if (!string.IsNullOrWhiteSpace(dto.ImageUrl))
                {
                    dto.ImageUrl = await _service.GetSignedUrl(dto.SavedImageUrl);
                }
            
                
        }
    }
}
