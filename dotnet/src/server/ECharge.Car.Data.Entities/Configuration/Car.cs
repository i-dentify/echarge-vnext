#region [ COPYRIGHT ]

// <copyright file="Car.cs" company="i-dentify Software Development">
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

namespace ECharge.Car.Data.Entities.Configuration
{
    #region [ References ]

    using ECharge.Data.Entities.Configuration;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Serializers;

    #endregion

    public class Car : IEntityTypeConfiguration<Entities.Car>
    {
        public void Configure()
        {
            BsonClassMap.RegisterClassMap<Entities.Car>(map =>
            {
                map.AutoMap();
                map.MapProperty(entity => entity.Id).SetSerializer(new GuidSerializer(BsonType.String));
            });
        }
    }
}