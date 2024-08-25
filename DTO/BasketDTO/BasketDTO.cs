using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BasketDTO
{
    public class BasketDTO
    {
        public List<BasketItemDTO> BasketItems { get; set; } = new List<BasketItemDTO>();
        public decimal TotalPrice { get; set; }
    }
}
