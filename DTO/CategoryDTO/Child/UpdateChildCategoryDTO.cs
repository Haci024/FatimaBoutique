using DTO.CategoryDTO.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CategoryDTO.Child
{
    public class UpdateChildCategoryDTO
    {
        public string Name { get; set; }

        public IEnumerable<MainCategoryListDTO> MainCategories { get; set; }

        public int MainCategoryId { get; set; }
    }
}
