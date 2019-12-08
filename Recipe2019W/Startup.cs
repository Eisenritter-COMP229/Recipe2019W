using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipe2019W.Models;

namespace Recipe2019W
{
    public class Startup
    {
        // public property
        // This Property store the configuration from appsettings
        public IConfiguration Configuration { get; }
        // Constructor
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Setup the database connection
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(Configuration["Data:Recipe2019W:ConnectionString"]));

            //Everytime time IRecipeRepository is called, it will create the repository
            services.AddTransient<IRecipeRepository, EFRecipeRepository>();
            // Add MVC Service
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // Status Code Errors
            app.UseStatusCodePages();
            // To use bootstrap files
            app.UseStaticFiles();
            // Initialize Routes
            app.UseMvc(routes =>
                {
                    // Category Routing
                    routes.MapRoute(
                        name: null,
                        template: "{category}/Page{recipePage:int}",
                        defaults: new { Controller = "Recipe", action = "List" }
                    );

                    routes.MapRoute(
                        name: null,
                        template: "Page{recipePage:int}",
                        defaults: new { Controller = "Recipe", action = "List", productPage = 1 }
                    );

                    routes.MapRoute(
                        name: null,
                        template: "{category}",
                        defaults: new { Controller = "Recipe", action = "List", productPage = 1 }
                    );

                    routes.MapRoute(
                        name: null,
                        template: "",
                        defaults: new { Controller = "Recipe", action = "List", productPage = 1 }
                    );

                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Recipe}/{action=List}/{id?}"
                    );
                }
            );
            // Send the database to the app
            SeedData.EnsurePopulated(app);
        }
    }
}
