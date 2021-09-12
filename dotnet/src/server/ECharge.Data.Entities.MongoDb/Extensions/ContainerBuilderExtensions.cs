#region [ COPYRIGHT ]

// <copyright file="ContainerBuilderExtensions.cs" company="i-dentify Software Development">
// Copyright (c) 2021 i-dentify Software Development (http://www.i-dentify.de) - All Rights Reserved.
// 
// Unauthorized copying of this file, via any medium is strictly prohibited.
// Proprietary and confidential.
// 
// </copyright>
// <author>Mario Adam</author>
// <email>mail@i-dentify.de</email>
// <date>2021-09-12</date>
// <summary></summary>

#endregion

namespace ECharge.Data.Entities.MongoDB.Extensions
{
    #region [ References ]

    using Autofac;
    using ECharge.Data.Entities.MongoDB.Configuration;
    using global::MongoDB.Driver;
    using Microsoft.Extensions.Options;

    #endregion

    public static class ContainerBuilderExtensions
    {
        #region [ Public methods ]

        public static ContainerBuilder RegisterMongoDb(this ContainerBuilder builder)
        {
            builder.Register(context =>
                {
                    IOptions<MongoDbOptions> options = context.Resolve<IOptions<MongoDbOptions>>();
                    return new MongoClient(options.Value.ConnectionString);
                })
                .As<IMongoClient>()
                .SingleInstance();

            builder.Register(context =>
                {
                    IOptions<MongoDbOptions> options = context.Resolve<IOptions<MongoDbOptions>>();
                    IMongoClient client = context.Resolve<IMongoClient>();
                    return client.GetDatabase(options.Value.Database);
                })
                .As<IMongoDatabase>()
                .SingleInstance();

            return builder;
        }

        #endregion
    }
}