#region [ COPYRIGHT ]

// <copyright file="CarWithNameDoesNotExist.cs" company="i-dentify Software Development">
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

namespace ECharge.Car.Query.Queries
{
    #region [ References ]

    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ECharge.Car.Data.Entities;
    using ECharge.Car.Query.Queries.Interfaces;
    using ECharge.Data.Entities.MongoDB.Extensions;
    using MongoDB.Driver;

    #endregion

    public class CarWithNameDoesNotExist : ICarWithNameDoesNotExist
    {
        #region [ Private attributes ]

        private readonly IMongoDatabase database;

        #endregion

        #region [ Constructor ]

        public CarWithNameDoesNotExist(IMongoDatabase database)
        {
            this.database = database;
        }

        #endregion

        #region [ Public methods ]

        public async Task<bool> ExecuteAsync(Parameters.Interfaces.ICarWithNameDoesNotExist parameters,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(parameters?.Name))
            {
                return false;
            }

            FilterDefinitionBuilder<Car> filterBuilder = Builders<Car>.Filter;
            FilterDefinition<Car> filter =
                Builders<Car>.Filter.Eq(car => car.Name, parameters.Name);

            if (!parameters.ExceptId.Equals(Guid.Empty))
            {
                filter &= filterBuilder.Eq(car => car.Id, parameters.ExceptId);
            }

            IAsyncCursor<Car> entities = await this.database.GetCollectionFromAnnotation<Car>()
                .FindAsync(filter, cancellationToken: cancellationToken);
            return !await entities.AnyAsync(cancellationToken);
        }

        #endregion
    }
}