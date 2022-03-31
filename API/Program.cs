using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;


namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();


            //ConfigureLogger();
            //Log.Information(messageTemplate: "Application Started");
            //try
            //{
            //    CreateHostBuilder(args).Build().Run();

            //}
            //finally
            //{
            //    Log.CloseAndFlush();
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .UseSerilog((hostingContext, LoggerConfiguration)=>
            {
            LoggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);


        });
        ////public static void ConfigureLogger()
        //{

        //    Log.Logger = new LoggerConfiguration()
        //        // log.logger = (serilog.ilogger)new loggerconfiguration()
        //       // .WriteTo.Console(outputTemplate: "{timestamp:yyy-mm-dd} {machinename} {threadid} {message} {exception:1} {newline}")
        //        //.WriteTo.File(path: @"log.txt", outputTemplate: "{timestamp:yyy-mm-dd} {machinename} {threadid} {message} {exception:1} {newline}"))
        //           // .enrich.withthreadid()
        //           // .enrich.withmachinename()
        //            .CreateLogger();


            
        //}
    }
}
