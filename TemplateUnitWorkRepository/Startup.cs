using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence.UnitOfWork;
using ServiceLayer;
using ServiceLayer.Contracts;
using AutoMapper;
using TemplateUnitWorkRepository.Mapper;

namespace TemplateUnitWorkRepository
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var connectionString = Configuration.GetConnectionString("dev");
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(connectionString));

            //Inject Service Layer
            services.AddScoped<IUserSL, UserSL>();
            services.AddScoped<IProductSL, ProductSL>();

            //Inject unit of work 
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // inject auto mapper
            services.AddAutoMapper(typeof(Startup));
         
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
