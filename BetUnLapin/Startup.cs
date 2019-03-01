using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BetUnLapin
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }

        
        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json",false,true)
                .AddJsonFile($"appsetings{environment.EnvironmentName}.json",true,true);
            this.Configuration = builder.Build();
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
           // app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoute);

            /*
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Bet un Lapin!");
            });
            */
            
        }
        // Du plus precis au moins precis dans la declaration de route
        private void ConfigureRoute (IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
               name: "about",
               template: "a-propos-de",
               defaults: new { controller = "Home", action = "About" });


            routeBuilder.MapRoute(
                name: "Default",
                template: "{controller}/{action}/{id?}",
                defaults: new {controller = "Home", action = "Index"});
        }
    }
}
