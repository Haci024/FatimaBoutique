using DTO.ContactUsDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.ContactUsValidator
{
    public class ContactUsValidator:AbstractValidator<AddContactUsDTO>
    {
        public ContactUsValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Zəhmət olmasa başlıq mətnini doldurun!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Zəhmət olmasa başlıq mətnini doldurun!");
            RuleFor(x => x.Gmail).NotEmpty().WithMessage("Elektron ünvanınızı daxil edin!");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Zəhmət olmasa Adınızı və soyadınızı daxil edin!");
        }
    }
}
