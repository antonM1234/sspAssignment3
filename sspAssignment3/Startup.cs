using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sspAssignment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sspAssignment3
{
    public class Startup
    {
        //This config injection is needed in order to access the appsetting.json file and retrieve the connection string
        private IConfiguration config;
        public Startup(IConfiguration config)
        {
            this.config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //Can't use AddSingleton here as it would throw an exception
            services.AddScoped<INurseRepository, NurseSQLRepository>();

            //This is used to retrieve the connection string from appsettings.json
            services.AddDbContextPool<NurseDbContext>(options => options.UseSqlServer(config.GetConnectionString("NurseDBConnection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute("default", "{controller=Home}/{action=index}/{id?}");

                /*
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                */
            });
        }
    }
}
