using Microsoft.Extensions.DependencyInjection;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class CustomIdentityService
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequireDigit = true; //Şifrede Sayı Gerekli olsun mu demektir.
                x.Password.RequiredLength = 8; // şifrede en az 8 karakter uzunluğunda olması gereklidir
                x.Password.RequireUppercase = true; // büyük harf gerekli olsun mu demektir
                x.Password.RequireLowercase = true; // küçük harf gerekli olsun mu demektir
                x.SignIn.RequireConfirmedEmail = true;
                x.User.RequireUniqueEmail = true;
                x.Password.RequireNonAlphanumeric = true; // numeric karakterler var zorunlu olsun mu demektir
                x.Lockout.MaxFailedAccessAttempts = 5; // 5 denemeden sonra kullanıcı yanlış giriyor ise hesabı kitlensin mi demektir
                x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // eğer hesab kitlenirse kaç dk kitlesin demektir

            }).AddEntityFrameworkStores<MyContext>();

            return services;
        }
    }
}
