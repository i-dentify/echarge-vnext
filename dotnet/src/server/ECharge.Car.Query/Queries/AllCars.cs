#region [ COPYRIGHT ]

// <copyright file="AllCars.cs" company="i-dentify Software Development">
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

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using ECharge.Car.Query.Queries.Interfaces;
    using ECharge.Data.Entities.MongoDB.Extensions;
    using MongoDB.Driver;
    using CarEntity = ECharge.Car.Data.Entities.Car;
    using CarViewModel = ECharge.Car.Models.Car;

    #endregion

    public class AllCars : IAllCars
    {
        #region [ Constructor ]

        public AllCars(IMongoDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        #endregion

        public async Task<IReadOnlyCollection<CarViewModel>> ExecuteAsync(
            CancellationToken cancellationToken = default)
        {
            IAsyncCursor<CarEntity> cursor = await this.database.GetCollectionFromAnnotation<CarEntity>()
                .FindAsync(Builders<CarEntity>.Filter.Empty, cancellationToken: cancellationToken);
            return new ReadOnlyCollection<CarViewModel>(
                this.mapper.Map<List<CarViewModel>>(await cursor.ToListAsync(cancellationToken)));
        }

        #region [ Private attributes ]

        private readonly IMongoDatabase database;
        private readonly IMapper mapper;

        #endregion
    }
}