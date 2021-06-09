using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Services;
using System;
using System.Linq;

namespace WebApplication1
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
            var options = new DbContextOptionsBuilder<MvcProjectContext>()
                    .UseSqlServer(Configuration.GetConnectionString("AppConnection"))
                    .Options;
            var context = new MvcProjectContext(options);

            context.Database.OpenConnection(); // this is where exception is thrown
            context.Database.EnsureCreated();

            // Contexts
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("AppConnection"))
            );

            services.AddDbContext<MvcProjectContext>(
                options => options.UseSqlite("DataSource=:memory:")
            );

            //services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UsersConnection")));

            // Custom services
            services.AddTransient<IEmailService, EmailService>();

            // Identity
            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 6;
                config.Password.RequireDigit = true;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = true;
                config.Password.RequireLowercase = true;
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

            // Other
            services.AddControllers(options =>
            {

            })
                .AddXmlSerializerFormatters()
                .AddNewtonsoftJson();

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

        private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
        {
            var builder = new ServiceCollection()
                .AddLogging()
                .AddMvc()
                .AddNewtonsoftJson()
                .Services.BuildServiceProvider();

            return builder
                .GetRequiredService<IOptions<MvcOptions>>()
                .Value
                .InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>()
                .First();
        }
    }
}
