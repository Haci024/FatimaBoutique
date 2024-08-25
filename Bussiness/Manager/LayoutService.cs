using DAL.DbConnection;
using DTO.BasketDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Manager
{
    public class LayoutService
    {
        private readonly Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LayoutService(Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<Products> GetProducts()
        {
            return _context.Products.ToList();
        }

        public BasketDTO GetBasket()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated && _httpContextAccessor.HttpContext.User.IsInRole("Member"))
            {
                var basketItems = _context.BasketItem.Include(x => x.Product).ThenInclude(x => x.ProductsImages).Where(x => x.AppUserId == _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
                var bv = new BasketDTO();
                foreach (var ci in basketItems)
                {
                    BasketItemDTO bi = new BasketItemDTO
                    {
                        Count = ci.Count,
                        Product = ci.Product
                    };
                    bv.BasketItems.Add(bi);
                    bv.TotalPrice += (bi.Product.Price) * bi.Count;
                }
                return bv;
            }
            else
            {
                var bv = new BasketDTO();
                var basketJson = _httpContextAccessor.HttpContext.Request.Cookies["basket"];

                if (basketJson != null)
                {
                    var cookieItems = JsonConvert.DeserializeObject<List<BasketItemCookieDTO>>(basketJson);

                    foreach (var ci in cookieItems)
                    {
                        BasketItemDTO bi = new BasketItemDTO
                        {
                            Count = ci.Count,
                            Product = _context.Products.Include(x => x.ProductsImages).FirstOrDefault(x => x.Id == ci.ProductId)
                        };
                        bv.BasketItems.Add(bi);
                        bv.TotalPrice += (bi.Product.Price) * bi.Count;
                    }
                }

                return bv;
            }

        }
    }
}
