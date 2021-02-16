using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_Project__online_shop_.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using MVC_Project__online_shop_.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using System;
using MVC_Project__online_shop_.Entities;

namespace MVC_Project__online_shop_
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(config =>
            {
                config.UseInMemoryDatabase("Memory");
            });
            services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UsersConnection")));
            services.AddDbContext<CategoryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CategoriesConnection")));
            services.AddDbContext<SubCategoryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SubCategoriesConnection")));

            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.User.RequireUniqueEmail = true;
                config.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
                config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30.0);
                config.Lockout.MaxFailedAccessAttempts = 5;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => 
                { 
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = new TimeSpan(0, 1, 0); 
                });

            services.AddControllers()
                .AddXmlSerializerFormatters();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerDocument();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            // Static files
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Swagger
            app.UseOpenApi();
            app.UseSwaggerUi3();

            // Routing, authentication, cookies, controllers mapping
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
