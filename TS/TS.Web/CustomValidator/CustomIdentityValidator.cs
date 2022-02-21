using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Web.CustomValidator
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        //IPasswordValidator<AppUser>
        //IUserValidator<AppUser>
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parola minumum {length} karakter olmalıdır"
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Parola bir alfanümerik karakter(!.~ vs.) içermelidir"
            };
        }

        public override IdentityError DuplicateUserName(string Username)
        {
            return new IdentityError()
            {
                Code = "DuplicateUserName",
                Description = $"İlgili kullanıcı adı ({Username}) sistemde kayıtlı"

            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Parola bir büyük harf['A'-'Z'] içermelidir"
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Parola bir küçük harf['a'-'z'] içermelidir"
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Parola bir rakam['0'-'9'] içermelidir"
            };
        }
    }
}