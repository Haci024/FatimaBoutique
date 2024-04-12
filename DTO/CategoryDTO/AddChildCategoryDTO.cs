using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MainCategoryDTO
{
    public class AddChildCategoryDTO
    {
        public int MainCategoryId { get; set; }

        public string CatgegoryName { get; set; }

        public List<Categories> Categories { get; set; }
    }
}
