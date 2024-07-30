using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IAppRoleRepository, AppRoleRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppUserProfileRepository, AppUserProfileRepository>();
            services.AddScoped<IAppUserRoleRepository, AppUserRoleRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();            
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieCategoryRepository, MovieCategoryRepository>();
            services.AddScoped<IMovieCommentRepository, MovieCommentRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IScreenRepository, ScreenRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISessionMovieRepository, SessionMovieRepository>();
            services.AddScoped<ISessionScreenRepository, SessionScreenRepository>();
            services.AddScoped<ISessionTicketRepository, SessionTicketRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            
            return services;
        }
    }
}
