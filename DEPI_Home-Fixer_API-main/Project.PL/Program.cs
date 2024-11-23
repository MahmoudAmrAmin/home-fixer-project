using Microsoft.AspNetCore.Authentication.Cookies;
using Project.BLL;
using Project.DAL;

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.RegisterBusinessLogicServices();

            builder.Services.RegisterDataAccessServices();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "YourAppAuthCookie"; 
                    options.LoginPath = "/Account/Login";
                    options.ExpireTimeSpan = TimeSpan.FromDays(30); 
                    options.SlidingExpiration = true; 
                    options.Cookie.HttpOnly = true; 
                    options.Cookie.IsEssential = true; 
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}


