using DotNetCoreFive_MVC_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace DotNetCoreFive_MVC_Project
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton(typeof(Customer));
            services
                .AddMvc((options) => {
                    var policy = new AuthorizationPolicyBuilder()
                                        .RequireAuthenticatedUser()
                                        .Build();
                    options.Filters.Add(new AuthorizeFilter(policy));
                }).AddXmlSerializerFormatters();
            services.AddIdentity<AppUser, IdentityRole>((options) =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            
            //services.AddRazorPages();
            //Configure url
            services.Configure<RouteOptions>((_routeOptions) =>
            {
                _routeOptions.AppendTrailingSlash = true;
                _routeOptions.LowercaseQueryStrings = true;
                _routeOptions.LowercaseUrls = true;
            });
            services.AddDbContextPool<ApplicationDbContext>((_connenction) =>
            {
                _connenction.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            });

            services.Add(new ServiceDescriptor(typeof(ICustomerRepository), typeof(SQLCustomerRepository), ServiceLifetime.Scoped));
            //services.AddSingleton<ICustomerRepository, CustomerImplementation>();
            //services.AddMvcCore();
            //services
            //    .AddMvc()
            //    .AddMvcOptions((_config) =>
            //    {
            //        _config.EnableEndpointRouting = false;
            //    });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints((_config) =>
            {

                //_config.MapRazorPages();
                    
                //Use for Attribute Routing  in ASPNET Core
                //_config.MapControllers();

                //Use for Conventional Rounting in ASPNET Core
                _config.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
                //_config.MapDefaultControllerRoute();
            });
            //app.UseMvcWithDefaultRoute();
            //app.UseWelcomePage();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("<h4 style='color:red;font-family:verdana;'>Request processing pipeline give up processing your request developer iamtuse!</h5>");
            //});

        }

       
    }
}
