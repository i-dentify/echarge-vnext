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

namespace ECharge.Car.Query.Queries.Parameters
{
    #region [ References ]

    using System;
    using ECharge.Car.Query.Queries.Parameters.Interfaces;

    #endregion

    public record CarWithNameDoesNotExist : ICarWithNameDoesNotExist
    {
        #region [ Public properties ]

        /// <summary>
        ///     Gets the car id to exclude.
        /// </summary>
        public Guid ExceptId { get; init; }

        /// <summary>
        ///     Gets the car name.
        /// </summary>
        public string Name { get; init; }

        #endregion
    }
}