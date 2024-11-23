using Microsoft.Extensions.DependencyInjection;
using Project.BLL.ServiceContracts;
using Project.BLL.Services;
using Project.DAL.UnitOfWork;

namespace Project.BLL
{
    public static class RegisterBusinessLogic
    {
        public static void RegisterBusinessLogicServices(this IServiceCollection services)
        {
           services.AddScoped<IUnitOfWork, UnitOfWork>();
           services.AddScoped<IRequestService, RequestService>();
           services.AddScoped<IOfferService, OfferService>();
           services.AddScoped<IAuthService, AuthService>();
           services.AddScoped<ISpecialization, SpecializationService>();
           services.AddScoped<ICityServece, CityService>();
           services.AddScoped<IPhotoService, PhotoService>();
           services.AddScoped<ITechnicianService, TechnicianService>();
           services.AddScoped<IClientService, ClientService>();
        }
    }
}

