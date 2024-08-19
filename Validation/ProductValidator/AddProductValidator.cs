using DTO.ProductsDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.ProductValidator
{
    public class AddProductValidator:AbstractValidator<AddProductDTO>
    {
        public AddProductValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kateqoriya seçimi edin!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Qiymət 0 və ya boş ola bilməz");
            RuleFor(x => x.Photos).NotEmpty().WithMessage("Minimum 1 rəsim seçilməlidir");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Azərbaycan  dilində açıqlama qeyd edilməyib!");
            RuleFor(x => x.Name).NotEmpty().WithMessage(" Azərbaycan  dilində məhsulun adı qeyd edilməyib!");
           
        }
    }
}
