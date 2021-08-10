using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RatersOfTheLostBusiness.Data;
using RatersOfTheLostBusiness.Models;
using RatersOfTheLostBusiness.Models.Interfaces;
using RatersOfTheLostBusiness.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BusinessDbContext>(options => {
                // Our DATABASE_URL from js days
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddSwaggerGen(options =>
            {
                // Make sure get the "using Statement"
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "RatersOfTheLostBusiness",
                    Version = "v1",
                });
            });
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                // There are other options like this
            })
            .AddEntityFrameworkStores<BusinessDbContext>();

            services.AddTransient<IBusiness, BusinessService>();
            services.AddTransient<IReviewer, ReviewerService>();
            services.AddTransient<IBusinessReview, BusinessReviewService>();
            services.AddTransient<IUser, IdentityUserService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger(options => {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/lesgo", async context =>
                {
                    await context.Response.WriteAsync("Project week is the best!");
                });

                // Swagger Stuff
                app.UseSwaggerUI(options => {
                    options.SwaggerEndpoint("/api/v1/swagger.json", "AsyncInn");
                    options.RoutePrefix = string.Empty;
                });

                // Swagger Stuff
                app.UseSwagger(options => {
                    options.RouteTemplate = "/api/{documentName}/swagger.json";
                });
            });
        }
    }
}
