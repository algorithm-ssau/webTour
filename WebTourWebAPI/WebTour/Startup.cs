using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using WebTour.DAL.Data;
using WebTour.Initialization;

namespace WebTour
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(optionsBuilder => optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Connection")));

            services.AddAsyncInitializer<DataInitializer>();

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("https://localhost:44356", "http://localhost:44356", "http://127.0.0.1:5000/", "https://127.0.0.1:5000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();

                });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
