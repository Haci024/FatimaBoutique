using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ProductImagesDTO
{
    public class ImageListDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string SavedImageUrl { get; set; }
        public bool IsMain { get; set; }
        public bool Status { get; set; }
        public int ProductId { get; set; }
    }
}
