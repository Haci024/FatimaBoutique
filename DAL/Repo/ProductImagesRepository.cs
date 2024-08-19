using DAL.DbConnection;
using Data.DAL;
using Data.Repositories;
using Entity.Models;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public class ProductImagesRepository:GenericRepository<ProductsImages>,IProductImagesDAL
    {
        private readonly Context _db;
        public ProductImagesRepository(Context db)
        {
            _db = db;
        }
        public string SelectFirstImageUrl(int productId)
        {
            return _db.ProductImages.Where(x => x.ProductId == productId).Select(x => x.ImageUrl).FirstOrDefault();
        }
        public string SelectLastImageUrl(int productId)
        {
            return _db.ProductImages.Where(x => x.ProductId == productId).Select(x => x.ImageUrl).LastOrDefault();
        }
    }
}
