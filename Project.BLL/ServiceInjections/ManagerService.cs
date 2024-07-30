using Microsoft.Extensions.DependencyInjection;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class ManagerService
    {
        public static IServiceCollection AddManagerServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));

            services.AddScoped<IAppRoleManager, AppRoleManager>();
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IAppUserProfileManager, AppUserProfileManager>();
            services.AddScoped<IAppUserRoleManager, AppUserRoleManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<ICityManager, CityManager>();
            services.AddScoped<ICommentManager, CommentManager>();
            services.AddScoped<IMovieManager, MovieManager>();
            services.AddScoped<IMovieCategoryManager, MovieCategoryManager>();
            services.AddScoped<IMovieCommentManager, MovieCommentManager>();
            services.AddScoped<IPlaceManager, PlaceManager>();
            services.AddScoped<IScreenManager, ScreenManager>();
            services.AddScoped<ISessionManager, SessionManager>();
            services.AddScoped<ISessionMovieManager, SessionMovieManager>();
            services.AddScoped<ISessionScreenManager, SessionScreenManager>();
            services.AddScoped<ISessionTicketManager, SessionTicketManager>();
            services.AddScoped<ITicketManager, TicketManager>();
            return services;
        }
    }
}
