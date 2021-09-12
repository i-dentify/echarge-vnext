#region [ COPYRIGHT ]

// <copyright file="Mutation.cs" company="i-dentify Software Development">
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

namespace ECharge.Car.Api.GraphQl
{
    #region [ References ]

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using ECharge.Car.Events;
    using ECharge.Car.Models.Input;
    using ECharge.EventSourcing.EventStore.Configuration;
    using ECharge.EventSourcing.EventStore.Extensions;
    using EventStore.Client;
    using Microsoft.Extensions.Options;

    #endregion

    public class Mutation
    {
        #region [ Constructor ]

        public Mutation(IMapper mapper, EventStoreClient eventStoreClient,
            IOptions<EventStoreOptions> eventStoreOptions)
        {
            this.mapper = mapper;
            this.eventStoreClient = eventStoreClient;
            this.eventStoreOptions = eventStoreOptions;
        }

        #endregion

        #region [ Public methods ]

        public async Task<CarAdded> AddCar(AddCar input)
        {
            CarAdded @event = this.mapper.Map<CarAdded>(input);
            await this.eventStoreClient.AppendToStreamAsync($"{this.eventStoreOptions.Value.StreamPrefix}-car",
                StreamState.Any,
                new List<EventData> { @event.ToEventData() });
            return @event;
        }

        #endregion

        #region [ Private attributes ]

        private readonly EventStoreClient eventStoreClient;
        private readonly IOptions<EventStoreOptions> eventStoreOptions;
        private readonly IMapper mapper;

        #endregion
    }
}