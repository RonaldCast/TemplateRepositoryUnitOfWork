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
using NSwag;
using ServiceLayer.Contracts;
using AutoMapper;
using TemplateUnitWorkRepository.Mapper;
using NSwag.Generation.Processors.Security;

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

            //configuration Swagger
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Template API ";
                    document.Info.Description = "Template API with Repository and unit of work";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Ronald Castillo",
                        Email = "ronaldcastillo789@gmail.com",
                        Url = "ronaldCastcode.com"
                    };
                   
                };
            });

           


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
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
            //configuration logger
            loggerFactory.AddFile(Configuration["Logging:PathFormat"]);

            //Add swagger for UI
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
