#region [ COPYRIGHT ]

// <copyright file="IMongoDatabaseExtensions.cs" company="i-dentify Software Development">
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

    using System.Reflection;
    using ECharge.Data.Entities.MongoDB.Attributes;
    using global::MongoDB.Driver;

    #endregion

    // ReSharper disable once InconsistentNaming
    public static class IMongoDatabaseExtensions
    {
        #region [ Public methods ]

        public static IMongoCollection<TDocument> GetCollectionFromAnnotation<TDocument>(this IMongoDatabase database,
            MongoCollectionSettings settings = null)
        {
            return database.GetCollection<TDocument>(typeof(TDocument).GetCustomAttribute<CollectionAttribute>()!.Name,
                settings);
        }

        #endregion
    }
}