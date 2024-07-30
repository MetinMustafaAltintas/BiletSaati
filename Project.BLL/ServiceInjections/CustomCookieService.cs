using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class CustomCookieService
    {
        public static IServiceCollection AddCookieServices(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(x =>
            {
                x.Cookie.HttpOnly = true; // oluşturduğumuz cookie yi göstermez
                x.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                x.Cookie.Name = "BiletSaati";
                x.ExpireTimeSpan = TimeSpan.FromDays(1);// Cookie nin geçerliliğinin süresini belirtiyoruz
                x.Cookie.SameSite = SameSiteMode.Strict; // o sitenin cookieleri sadece o site için geçerlidir
                x.LoginPath = new PathString("/Home/SignIn"); // kişi bulunamadığında yönlendirileceği sayfa
                x.AccessDeniedPath = new PathString("/Home/AccessDenied"); // eğer kişinin yetkisi yetmiyorsa yönlendirileceği sayfa
            });

            return services;
        }
    }
}
