using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Blogs
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Admin bir düymə basacaq onnan sonra SalesStatus (Endirim Statusu) aktiv olur və qiymətlər
        /// yalnız admin tərəfindən təyin edilmiş istifadəçiyə göstərilsin.
        /// </summary>
        public bool SalesStatus { get; set; }
        public decimal SalesPrice { get; set; }

        public bool IsSales { get; set; } = false;
        public decimal DiscountPrice { get; set; }
        public bool Status { get; set; }
        public List<BlogImages> BlogImages { get; set; }//Bloq rəsimləri
        public int ViewCount { get; set; }//Baxış sayı
        /// <summary>
        /// Üzük ölçüləri burda saxlanacaq
        /// </summary>
        public DateTime AddingDate { get; set; }
        public Categories Categories { get; set; }
        public int CategoryId { get; set; }
        public List<BlogsLanguage> BlogLanguages { get; set; }
    }

    public class BlogsLanguage
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int BlogsId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public Language Language { get; set; }
        public Blogs Blogs { get; set; }
    }
}
