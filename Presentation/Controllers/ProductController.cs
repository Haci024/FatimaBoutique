using DAL.DbConnection;
using DTO.BasketDTO;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly Context _context;

        public ProductController(Context context)
        {
            _context = context;
        }
        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            Products product = _context.Products
                .Include(x => x.ProductsImages)
                .Include(x => x.Categories)
                .FirstOrDefault(x => x.Id == id);

            if (product == null) return View("Error");

            return PartialView("~/Views/Shared/Modals/_QuickViewPartial.cshtml", product);
        }

        public IActionResult AddToBasket(int id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Member"))
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var basketItem = _context.BasketItem.FirstOrDefault(x => x.ProductId == id && x.AppUserId == userId);
                if (basketItem != null) basketItem.Count++;
                else
                {
                    basketItem = new BasketItem { AppUserId = userId, ProductId = id, Count = 1 };
                    _context.BasketItem.Add(basketItem);
                }
                _context.SaveChanges();
                var basketItems = _context.BasketItem.Include(x => x.Product).ThenInclude(x => x.ProductsImages).Where(x => x.AppUserId == userId).ToList();


                return PartialView("_BasketPartialView", GenerateBasketVM(basketItems));
            }
            else
            {
                List<BasketItemCookieDTO> cookieItems = new List<BasketItemCookieDTO>();

                BasketItemCookieDTO cookieItem;
                var basketStr = Request.Cookies["basket"];
                if (basketStr != null)
                {
                    cookieItems = JsonConvert.DeserializeObject<List<BasketItemCookieDTO>>(basketStr);

                    cookieItem = cookieItems.FirstOrDefault(x => x.ProductId == id);

                    if (cookieItem != null)
                        cookieItem.Count++;
                    else
                    {
                        cookieItem = new BasketItemCookieDTO { ProductId = id, Count = 1 };
                        cookieItems.Add(cookieItem);
                    }
                }
                else
                {
                    cookieItem = new BasketItemCookieDTO { ProductId = id, Count = 1 };
                    cookieItems.Add(cookieItem);
                }

                Response.Cookies.Append("Basket", JsonConvert.SerializeObject(cookieItems));
                return PartialView("_BasketPartialView", GenerateBasketVM(cookieItems));
            }
        }

        private BasketDTO GenerateBasketVM(List<BasketItemCookieDTO> cookieItems)
        {
            BasketDTO bv = new BasketDTO();
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

            return bv;
        }

        private BasketDTO GenerateBasketVM(List<BasketItem> basketItems)
        {
            BasketDTO bv = new BasketDTO();
            foreach (var item in basketItems)
            {
                BasketItemDTO bi = new BasketItemDTO
                {
                    Count = item.Count,
                    Product = item.Product
                };
                bv.BasketItems.Add(bi);
                bv.TotalPrice += (bi.Product.Price) * bi.Count;
            }
            return bv;
        }


        public IActionResult RemoveBasket(int id)
        {
            var basketStr = Request.Cookies["basket"];
            if (basketStr == null)
                return StatusCode(404);

            List<BasketItemCookieDTO> cookieItems = JsonConvert.DeserializeObject<List<BasketItemCookieDTO>>(basketStr);

            BasketItemCookieDTO item = cookieItems.FirstOrDefault(x => x.ProductId == id);

            if (item == null)
                return StatusCode(404);

            if (item.Count > 1)
                item.Count--;
            else
                cookieItems.Remove(item);

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(cookieItems));

            BasketDTO bv = new BasketDTO();
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

            return PartialView("_BasketPartialView", bv);
        }

        public IActionResult ShowBasket()
        {
            var basket = new List<BasketItemCookieDTO>();
            var basketStr = Request.Cookies["basket"];

            if (basketStr != null)
                basket = JsonConvert.DeserializeObject<List<BasketItemCookieDTO>>(basketStr);

            return Json(new { basket });
        }
    }
}
