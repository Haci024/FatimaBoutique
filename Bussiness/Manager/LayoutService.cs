using DAL.DbConnection;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Manager
{
    public class LayoutService
    {
        private readonly Context _context;

        public LayoutService(Context context)
        {
            _context = context;
        }

        public List<Products> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}
