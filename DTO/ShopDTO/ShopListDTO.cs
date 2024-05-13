using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ShopDTO
{
    public class ShopListDTO
    {
        public List<Blogs> Products { get; set; } = new List<Blogs>();
        public List<Categories> Categories { get; set; }
    }
}
