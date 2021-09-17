using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managemail.Alpha
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            The AddControllers() extension method adds the services required to use Web API Controllers, and nothing more. 
            So you get Authorization, Validation, formatters, and CORS for example, but nothing related to Razor Pages or view rendering. 
            This is important as we are using only Web API not MVC in this project
             */
            var mvcBuilderService = services.AddControllers();
            mvcBuilderService.PartManager.ApplicationParts.Add(new AssemblyPart(System.Reflection.Assembly.Load("Managemail.Web")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //This only maps controllers that are decorated with routing attributes - it doesn't configure any conventional routes
                endpoints.MapControllers();
            });
        }
    }
}
