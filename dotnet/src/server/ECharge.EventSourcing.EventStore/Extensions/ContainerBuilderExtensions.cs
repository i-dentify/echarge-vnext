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

namespace ECharge.EventSourcing.EventStore.Extensions
{
    #region [ References ]

    using Autofac;
    using ECharge.EventSourcing.EventStore.Configuration;
    using global::EventStore.Client;
    using Microsoft.Extensions.Options;

    #endregion

    public static class ContainerBuilderExtensions
    {
        #region [ Public methods ]

        public static ContainerBuilder RegisterEventStore(this ContainerBuilder builder)
        {
            builder.Register(context =>
                {
                    IOptions<EventStoreOptions> options = context.Resolve<IOptions<EventStoreOptions>>();
                    EventStoreClientSettings settings = EventStoreClientSettings.Create(options.Value.ConnectionString);
                    return new EventStoreClient(settings);
                })
                .AsSelf()
                .SingleInstance();

            return builder;
        }

        #endregion
    }
}