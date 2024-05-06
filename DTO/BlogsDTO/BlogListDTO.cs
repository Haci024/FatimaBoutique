using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BlogsDTO
{
    public class BlogListDTO
    {
        public IEnumerable<Blogs> Blogs { get; set; }
    }
}
