using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CategoryDTO.Child
{
    public class NavbarCategoryListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ChildCategoryListDTO> ChildCategories { get; set; }

        public ICollection<ThirdCategoryListDTO> ThirdLevelCategories { get; set; }

    }
}
