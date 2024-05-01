using DTO.UserDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.AppUserValidator
{
    public class RegisterValidator:AbstractValidator<RegisterUserDTO>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrə təyin edin!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifrə təkrarı boş ola bilməz!").Equal(x => x.Password).WithMessage("Şifrələr eyni deyil!");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Elektron ünvanınızı daxil edin...");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Alış-veriş zamanı sizə müraciət etməyimiz üçün adınızı daxil edin ...");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon nömrənizi  daxil edin...");
        }
    }
}
