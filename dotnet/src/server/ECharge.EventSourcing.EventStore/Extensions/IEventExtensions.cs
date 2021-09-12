#region [ COPYRIGHT ]

// <copyright file="IEventExtensions.cs" company="i-dentify Software Development">
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

    using System.Collections.Generic;
    using System.Text;
    using System.Text.Json;
    using ECharge.Core.EventSourcing;
    using global::EventStore.Client;

    #endregion

    public static class IEventExtensions
    {
        #region [ Public methods ]

        public static EventData ToEventData<T>(this T @event, IDictionary<string, object> headers = null)
            where T : IEvent
        {
            byte[] data = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@event));
            Dictionary<string, object> eventHeaders = new(headers ?? new Dictionary<string, object>())
            {
                {
                    "EventClrType", @event.GetType().AssemblyQualifiedName!
                }
            };
            byte[] metadata = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(eventHeaders));
            string typeName = @event.GetType().Name;

            return new EventData(Uuid.NewUuid(), typeName, data, metadata);
        }

        #endregion
    }
}