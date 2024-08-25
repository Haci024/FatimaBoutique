using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public string AppUserId { get; set; }

        public Products Product { get; set; }
        public AppUser AppUser { get; set; }
    }
}
