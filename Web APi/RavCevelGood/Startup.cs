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
using Microsoft.AspNetCore.Http.Features;

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
            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExtraSchool", Version = "v1" });
            });







            //services.Configure<FormOptions>(options =>
            //{
            //    options.MultipartBodyLengthLimit = 60000000;
            //});
            //services.Configure<FormOptions>(o =>  // currently all set to max, configure it to your needs!
            //{
            //    o.ValueLengthLimit = int.MaxValue;
            //    o.MultipartBodyLengthLimit = long.MaxValue; // <-- !!! long.MaxValue
            //    o.MultipartBoundaryLengthLimit = int.MaxValue;
            //    o.MultipartHeadersCountLimit = int.MaxValue;
            //    o.MultipartHeadersLengthLimit = int.MaxValue;
            //});
            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = long.MaxValue; // you can customize the maximum file size as per your need 

            });
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = long.MaxValue; // you can customize the maximum file size as per your need 

            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RavCevelGood v1"));
            }

            app.UseHttpsRedirection();

            //האם זה בטיחותי??????????
             app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

        app.UseHttpsRedirection(); 

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

          


            //_IMailService.SendEmail("ravcevel@gmail.com", "publish", DateTime.UtcNow.ToString());

        }


        // Register AutoMapper 
    }
}
