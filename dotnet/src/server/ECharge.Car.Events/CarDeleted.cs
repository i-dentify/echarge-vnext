#region [ COPYRIGHT ]

// <copyright file="CarDeleted.cs" company="i-dentify Software Development">
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

namespace ECharge.Car.Events
{
    #region [ References ]

    using System;
    using ECharge.Car.Events.Interfaces;

    #endregion

    public record CarDeleted : ICarDeleted
    {
        #region [ Public properties ]

        public Guid Id { get; init; }

        #endregion
    }
}