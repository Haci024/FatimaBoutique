using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public bool Status { get; set; }    
        public ICollection<Categories> ChildCategories { get; set; }
        public Categories MainCategory { get; set; }
        public int? MainCategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
