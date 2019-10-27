using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using StoreExample.Interfaces;
using StoreExample.Repositories;
using StoreExample.Services;

namespace StoreExample
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
            string connectionString = Configuration.GetConnectionString(Configuration["Environment"]);

            services.AddDbContext<StoreContext>(options => options.UseSqlServer(connectionString));
            services
                .AddSingleton<IAppServices, AppServices>()
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddScoped<IStockServices, StockServices>();

            services
                .AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo {Title = "Store Example API", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app
                .UseSwagger()
                .UseSwaggerUI(s => {
                    s.RoutePrefix = "swagger";
                    s.DisplayRequestDuration();
                    s.DefaultModelsExpandDepth(-1);
                    s.SwaggerEndpoint("v1/swagger.json", "Store Example API v1");
                });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}