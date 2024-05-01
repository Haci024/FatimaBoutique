using Microsoft.AspNetCore.Identity;

namespace Validation.AppUserVal
{
	public class CustomIdentityValidator:IdentityErrorDescriber
	{
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresDigit",
				Description = "Ən az 1 rəqəm olmalıdır!"
			};
		}
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError
			{
				Code = "PasswordTooShort",
				Description = $"Şifrə minimum {length} simvoldan ibarət olmalıdır!"
			};
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresUpper",
				Description = "Şifrədə ən az 1 böyük hərf olmalıdır!"
			};
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError
			{
				Code= "PasswordRequiresLower",
				Description= "Şifrədə ən az 1 kiçik hərf olmalıdır!"
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "Minimum 1 simvol olmalıdır!"
			};
		}
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = "DuplicateEmail",
                Description = $"{email} adlı elektron ünvan artıq qeydiyyatdan keçib!"
            };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = "DuplicateUserName",
                Description = $"{userName} adlı istifadəçi  artıq qeydiyyatdan keçib!"
            };
        }   
    }
}

	/*Qeydiyyat zamanı gələn xətalar Azərbaycan dilinə çevirmək üçün model yaratdıq.Model İdentityErrorDescriber-dan
	miras alır və metodlarından istifadə edir*/
	//Suallar
	//Override nədir?

