using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CategoryDTO
{
    public class UpdateChildCategoryDTO
    {
        public int MainCategoryId { get;set; }

        public List<Categories> Categories { get; set; }    

        public string CategoriesName { get; set; }  
    }
}
