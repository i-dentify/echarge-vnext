#region [ COPYRIGHT ]

// <copyright file="Program.cs" company="i-dentify Software Development">
// Copyright (c) 2021 i-dentify Software Development (http://www.i-dentify.de) - All Rights Reserved.
// 
// Unauthorized copying of this file, via any medium is strictly prohibited.
// Proprietary and confidential.
// 
// </copyright>
// <author>Mario Adam</author>
// <email>mail@i-dentify.de</email>
// <date>2021-09-05</date>
// <summary></summary>

#endregion

namespace ECharge.Car.Api
{
    #region [ References ]

    using System;
    using System.IO;
    using Autofac.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Serilog;

    #endregion

    public class Program
    {
        #region [ Public attributes ]

        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile(
                $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",
                true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables()
            .Build();

        #endregion

        #region [ Public methods ]

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            try
            {
                Log.Information("Starting application...");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        #endregion

        #region [ Private methods ]

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webHostBuilder =>
                {
                    webHostBuilder
                        .UseKestrel(options => options.AddServerHeader = false)
                        .UseStartup<Startup>()
                        .UseConfiguration(Configuration);
                })
                .UseSerilog();
        }

        #endregion
    }
}