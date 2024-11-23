using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Context;
using Project.DAL.Entities;
using Project.DAL.Interfaces;
using Project.DAL.Repositories;

namespace Project.DAL
{
    public static class RegisterDataAccess
    {
        public static void RegisterDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<ITechnicianRepository, TechnicianRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<ISpecializationRepository, SpecializationRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITechnicianRepository, TechnicianRepository>();

            services.AddDbContext<DEPIProjectContext>();

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;


                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_@";
                options.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<DEPIProjectContext>()
              .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);
        }
    }
}
