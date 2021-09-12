#region [ COPYRIGHT ]

// <copyright file="Query.cs" company="i-dentify Software Development">
// Copyright (c) 2021 i-dentify Software Development (http://www.i-dentify.de) - All Rights Reserved.
// 
// Unauthorized copying of this file, via any medium is strictly prohibited.
// Proprietary and confidential.
// 
// </copyright>
// <author>Mario Adam</author>
// <email>mail@i-dentify.de</email>
// <date>2021-09-05</date>
// <summary></summary>

#endregion

namespace ECharge.Car.Api.GraphQl
{
    #region [ References ]

    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ECharge.Car.Models;
    using ECharge.Car.Query.Queries.Interfaces;

    #endregion

    public class Query
    {
        #region [ Private attributes ]

        private readonly IAllCars allCars;

        #endregion

        #region [ Constructor ]

        public Query(IAllCars allCars)
        {
            this.allCars = allCars;
        }

        #endregion

        #region [ Public methods ]

        public Task<IReadOnlyCollection<Car>> GetCars(CancellationToken cancellationToken)
        {
            return this.allCars.ExecuteAsync(cancellationToken);
        }

        #endregion
    }
}