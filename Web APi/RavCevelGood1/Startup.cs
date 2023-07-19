using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB;
using AutoMapper;
//using DB.Model;
using DTO;
using Microsoft.OpenApi.Models;
using Services.Interfaces;

namespace RavCevelGood
{
    public class Startup
    {
        //private readonly IMailService _IMailService;

        public Startup(IConfiguration configuration/*, IMailService iMailService*/)
        {
            Configuration = configuration;
            //_IMailService = iMailService;
        }

        public IConfiguration Configuration { get; }
        public ILoggerFactory LoggerFactory { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterPayContext(Configuration, LoggerFactory);
            //services.RegisterPayAidServices();
            services.RegisterPayServicesRepositor();
            services.RegisterPayServicesService();

            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RavCevelGood", Version = "v1" });
            });

           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RavCevelGood v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //_IMailService.SendEmail("tovazilber737@gmail.com", "publish", DateTime.UtcNow.ToString());

        }


        // Register AutoMapper 
    }
}
