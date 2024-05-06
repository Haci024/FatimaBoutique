using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Orders
    {
        public int Id { get; set; } 
        public decimal Price { get; set; }
        public int count { get; set; }
        public List<OrderLanguage> OrderLanguages { get; set; }
    }

    public class OrderLanguage
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int OrderId { get; set; }

        public string Title { get; set; }

        public Language Language { get; set; }
        public Orders Orders { get; set; }
    }
}
