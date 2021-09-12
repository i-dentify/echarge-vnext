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

namespace ECharge.Car.Data.Entities
{
    #region [ References ]

    using System;
    using ECharge.Data.Entities;
    using ECharge.Data.Entities.MongoDB.Attributes;

    #endregion

    [Collection("cars")]
    public class Car : IEntity
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public byte BatteryCapacity { get; init; }
    }
}