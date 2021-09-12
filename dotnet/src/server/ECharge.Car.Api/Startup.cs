#region [ COPYRIGHT ]

// <copyright file="Startup.cs" company="i-dentify Software Development">
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
    using System.Globalization;
    using System.IO.Compression;
    using System.Linq;
    using System.Reflection;
    using Autofac;
    using AutoMapper.Contrib.Autofac.DependencyInjection;
    using ECharge.Car.Api.GraphQl.Types;
    using ECharge.Car.Query.Extensions;
    using ECharge.Data.Entities.MongoDB.Configuration;
    using ECharge.Data.Entities.MongoDB.Extensions;
    using ECharge.EventSourcing.EventStore.Configuration;
    using ECharge.EventSourcing.EventStore.Extensions;
    using HealthChecks.UI.Client;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics.HealthChecks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.ResponseCompression;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyModel;
    using Microsoft.Extensions.Diagnostics.HealthChecks;
    using Microsoft.Extensions.Hosting;

    #endregion

    public class Startup
    {
        #region [ Constructor ]

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        #endregion

        #region [ Private properties ]

        private IConfiguration Configuration { get; }

        #endregion

        #region [ Public methods ]

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddOptions()
                .Configure<EventStoreOptions>(this.Configuration.GetSection("EventStore"))
                .Configure<MongoDbOptions>(this.Configuration.GetSection("MongoDb"))
                .Configure<DataProtectionTokenProviderOptions>(options =>
                {
                    options.TokenLifespan = TimeSpan.FromMinutes(15);
                })
                .Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);

            services
                .AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy());

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services
                .AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        policyBuilder => policyBuilder.SetIsOriginAllowed(_ => true).AllowAnyMethod()
                            .AllowAnyHeader().AllowCredentials());
                });

            services
                .AddResponseCompression(options => { options.EnableForHttps = true; });
            
            services.AddGraphQLServer()
                .AddQueryType<QueryType>()
                .AddMutationType<MutationType>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAutoMapper(DependencyContext.Default.GetDefaultAssemblyNames()
                .Where(assembly => !string.IsNullOrWhiteSpace(assembly.Name) &&
                                   (assembly.Name.Equals("ECharge.Car.Mapping"))).Select(Assembly.Load).ToArray());
            builder.RegisterEventStore();
            builder.RegisterMongoDb();
            builder.RegisterQueries();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            CultureInfo[] supportedCultures = new[]
                {
                    "de-DE",
                    "en-US"
                }
                .Select(code => new CultureInfo(code)).ToArray();

            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage();
            }
            else
            {
                app
                    .UseHttpsRedirection()
                    .UseHsts();
            }

            app
                .UseCors("CorsPolicy")
                .UseRequestLocalization(new RequestLocalizationOptions
                {
                    DefaultRequestCulture = new RequestCulture("en-US"),
                    SupportedCultures = supportedCultures,
                    SupportedUICultures = supportedCultures
                })
                .UseResponseCompression()
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                    endpoints.MapHealthChecks("/hc", new HealthCheckOptions
                    {
                        Predicate = _ => true,
                        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                    });
                    endpoints.MapHealthChecks("/liveness", new HealthCheckOptions
                    {
                        Predicate = r => r.Name.Contains("self")
                    });
                });
        }

        #endregion
    }
}