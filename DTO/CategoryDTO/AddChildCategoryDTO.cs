using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CategoryDTO
{
    public class AddChildCategoryDTO
    {
        public int MainCategoryId { get; set; }
        public List<Categories> MainCategoryList { get; set; }
   

        public string CategoryName_az { get; set; }

        public string CategoryName_tr { get; set; }

        public string CategoryName_en { get; set; }

        public string CategoryName_ru { get; set; }
    }

}
