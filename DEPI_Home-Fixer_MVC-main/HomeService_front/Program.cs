using ApiServiceLayer.Services.APIServices;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HomeService_front
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddHttpClient<IAPIService, APIService>();

            builder.Services.AddHttpClient< IAPIService, APIService > (client =>
            {

                client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]);
            });

            // Add authentication service with cookie authentication
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
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
