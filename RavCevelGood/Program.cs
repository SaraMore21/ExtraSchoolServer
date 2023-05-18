using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//using Serilog;
//using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;



namespace RavCevelGood
{
    public class Program
    {

      //  public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
      //  .SetBasePath(Directory.GetCurrentDirectory())
      //  .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
      //// .AddJsonFile($"appSettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
      //  .Build();

        [Obsolete]
        public static void Main(string[] args)
        {
            //var columnOptions = new ColumnOptions
            //{
            //    AdditionalDataColumns = new Collection<DataColumn>
            //    {
            //        new DataColumn {ColumnName = "UserName", DataType = typeof(string)}
            //    }
            //};

            //columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            //columnOptions.Store.Remove(StandardColumn.LogEvent);
            //columnOptions.Store.Remove(StandardColumn.Properties);

            //Serilog.Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(Configuration)
            //    //.WriteTo.File(@"\\iislogs\Logs\PaymentAid\log.txt")
            //    .WriteTo.MSSqlServer(Configuration.GetConnectionString("ExtraSchool"),
            //     "Logs", columnOptions: columnOptions, autoCreateSqlTable: false).Enrich
            //     .FromLogContext().CreateLogger();


            CreateHostBuilder(args).Build().Run();
        
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


    }
}
