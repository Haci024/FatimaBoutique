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
        public List<Categories> ChildCategories { get; set; }
        public Categories MainCategory { get; set; }
        public int? MainCategoryId { get; set; }
        public List<Blogs> Blogs { get; set; }
        public List<CategoryLanguage> CategoryLanguages { get; set; }
    }

    public class CategoryLanguage
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Language Language { get; set; }
        public Categories Categories { get; set; }
    }

}
