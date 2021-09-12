#region [ COPYRIGHT ]

// <copyright file="ICarWithNameDoesNotExist.cs" company="i-dentify Software Development">
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

namespace ECharge.Car.Query.Queries.Parameters.Interfaces
{
    #region [ References ]

    using System;
    using ECharge.Core.Data.Query.Interfaces;

    #endregion

    public interface ICarWithNameDoesNotExist : IQueryParameters
    {
        #region [ Properties ]

        /// <summary>
        ///     Gets the car id to exclude.
        /// </summary>
        Guid ExceptId { get; }

        /// <summary>
        ///     Gets the car name.
        /// </summary>
        string Name { get; }

        #endregion
    }
}