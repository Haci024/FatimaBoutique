using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CategoryDTO.Child
{
    public class ChildCategoryListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool  Status { get; set; }

        public int MainCategoryId { get; set; }

        public string MainCategoryName { get; set; }

        public ICollection<ThirdCategoryListDTO> ThirdCategories { get; set; }
    }
}
