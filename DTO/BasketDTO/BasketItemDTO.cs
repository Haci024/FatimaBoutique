using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BasketDTO
{
    public class BasketItemDTO
    {
        public Products Product { get; set; }
        public int Count { get; set; }
    }
}
