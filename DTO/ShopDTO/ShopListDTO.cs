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
        public List<Products> Products { get; set; } = new List<Products>();
        public List<Categories> Categories { get; set; }
    }
}
