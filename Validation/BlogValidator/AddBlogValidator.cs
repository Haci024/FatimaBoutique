using DTO.BlogsDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.BlogValidator
{
    public class AddBlogValidator:AbstractValidator<AddBlogDTO>
    {
        public AddBlogValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kateqoriya seçimi edin!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Qiymət 0 və ya boş ola bilməz");
            RuleFor(x => x.Photos).NotEmpty().WithMessage("Minimum 1 rəsim seçilməlidir");
            RuleFor(x => x.Description_az).NotEmpty().WithMessage("Azərbaycan  dilində açıqlama qeyd edilməyib!");
            RuleFor(x => x.Description_tr).NotEmpty().WithMessage("Türk  dilində açıqlama qeyd edilməyib!");
            RuleFor(x => x.Description_en).NotEmpty().WithMessage("İngilis  dilində açıqlama qeyd edilməyib!");
            RuleFor(x => x.Description_ru).NotEmpty().WithMessage("Rus  dilində açıqlama qeyd edilməyib!");
            RuleFor(x => x.Title_az).NotEmpty().WithMessage(" Azərbaycan  dilində məhsulun adı qeyd edilməyib!");
            RuleFor(x => x.Title_tr).NotEmpty().WithMessage("Türk  dilində məhsulun adı qeyd edilməyib!");
            RuleFor(x => x.Title_en).NotEmpty().WithMessage("İngilis  dilində məhsulun adı qeyd edilməyib!");
            RuleFor(x => x.Title_ru).NotEmpty().WithMessage("Rus  dilində məhsulun adı qeyd edilməyib!");
        }
    }
}
