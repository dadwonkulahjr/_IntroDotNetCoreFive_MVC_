using DotNetCoreFive_MVC_Project.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
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
            services
                .AddMvc()
                .AddXmlSerializerFormatters();
            //Configure url
            services.Configure<RouteOptions>((_routeOptions) =>
            {
                _routeOptions.AppendTrailingSlash = true;
                _routeOptions.LowercaseQueryStrings = true;
                _routeOptions.LowercaseUrls = true;
            });
                
                
            services.Add(new ServiceDescriptor(typeof(ICustomerRepository), typeof(CustomerImplementation), ServiceLifetime.Singleton));
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
            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints((_config) =>
            {
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
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("iamtuseTheProgrammertech.com");
            });
        }
    }
}
