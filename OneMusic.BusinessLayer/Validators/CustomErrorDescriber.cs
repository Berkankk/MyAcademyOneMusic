using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.BusinessLayer.Validators
{
    public class CustomErrorDescriber : IdentityErrorDescriber
    {
        // burada hataları override edeceğiz 

        public override IdentityError PasswordTooShort(int length) //şifre uzunluğu için hata mesajı
        {
            return new IdentityError
            {
                Description = "Şifre en az 6 karakterden oluşmalıdır!"
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir tane rakam(1-3-7) içermelidir!"
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir küçük harf(a-b-ü) içermelidir!"
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir büyük harf(A-B-Ü) içermelidir!"
            };

        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Description = "Şifre en az bir özel karakter(+ - !) içermelidir!"
            };
        }
        public override IdentityError InvalidUserName(string? userName)
        {
            return new IdentityError
            {
                Description = "Bu kullanıcı adını kullanamazsınız"
            };
        }


        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Description = "Bu kullanıcı adı daha önce alınmıştır"
            };
        }
    }
}
