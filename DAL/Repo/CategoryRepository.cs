using DAL.DbConnection;
using Data.DAL;
using Data.Repositories;
using DTO.CategoryDTO.Child;
using DTO.CategoryDTO.Main;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public class CategoryRepository:GenericRepository<Categories>,ICategoryDAL
    {
        private readonly Context _db;

        public CategoryRepository(Context db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ChildCategoryListDTO>> ActiveChildCategoryList()
        {
            var categories = await _db.Categories.Where(x => x.MainCategoryId != null && x.Status==true && x.MainCategory.Status==true).Select(x => new ChildCategoryListDTO
            {
                Id=x.Id,
                MainCategoryId = (int)x.MainCategoryId,
                Name = x.Name,
                Status = x.Status,
                MainCategoryName=x.MainCategory.Name,
            }).ToListAsync();
            return categories;
        }

        public async Task<IEnumerable<MainCategoryListDTO>> ActiveMainCategoryList()
        {
            var categories = await _db.Categories.Where(x => x.MainCategoryId == null).Select(x => new MainCategoryListDTO
            {
                Id = (int)x.Id,
                Name = x.Name,
                Status = x.Status,


            }).ToListAsync();
            return categories;
        }
        public async Task<IEnumerable<ChildCategoryListDTO>> ChildCategoryListByMain(int mainCategoryId)
        {
            var data = await _db.Categories.Where(x => x.MainCategoryId == mainCategoryId && x.Status==true).Select(x => new ChildCategoryListDTO
            {
                Id=x.Id,
                MainCategoryId=(int)x.MainCategoryId,
                Name=x.Name,
                Status = x.Status,
                MainCategoryName=x.MainCategory.Name,

            }).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<ChildCategoryListDTO>> DeactiveChildCategoryList()
        {
            var data=await _db.Categories.Where(x=>x.MainCategoryId!=null && x.Status==false).Select(x=> new ChildCategoryListDTO
            {
                Id=x.Id,
                MainCategoryId= (int)x.MainCategoryId,
                Name = x.Name,
                Status = x.Status,

            }).ToListAsync();
            return data;
        }

      
        /// <summary>
        /// Aktiv kateqoriyaları əsas kateqoriyaları ilə birlikdə gətirir
        /// </summary>



        public IEnumerable<NavbarCategoryListDTO> NavbarCategoryList()
        {

            var categories = _db.Categories.Where(x => x.Status == true).Select(x => new NavbarCategoryListDTO
            {
                Id = x.Id,
                Name = x.Name,
                ChildCategories = x.ChildCategories.Select(y => new ChildCategoryListDTO
                {
                    MainCategoryId = (int)y.MainCategoryId,
                    Name = y.Name,
                    Status = y.Status,
                    MainCategoryName = x.Name,
                    ThirdCategories = y.ChildCategories.Select(t => new ThirdCategoryListDTO
                    {
                        Id=(int)t.Id,
                        Name=t.Name,
                        Status = t.Status,
                        MainCategoryName=t.MainCategory.Name,

                    }).ToList(),




                }).ToList(),

            }) ;

            return categories;
        }
    }
}
