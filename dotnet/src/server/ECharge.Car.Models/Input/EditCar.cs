#region [ COPYRIGHT ]

// <copyright file="EditCar.cs" company="i-dentify Software Development">
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

namespace ECharge.Car.Models.Input
{
    #region [ References ]

    using System;

    #endregion

    public record EditCar
    {
        #region [ Public properties ]

        public Guid Id { get; init; }
        public string Name { get; init; }
        public byte BatteryCapacity { get; init; }

        #endregion
    }
}