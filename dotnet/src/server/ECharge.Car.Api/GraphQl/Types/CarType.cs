#region [ COPYRIGHT ]

// <copyright file="CarType.cs" company="i-dentify Software Development">
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

namespace ECharge.Car.Api.GraphQl.Types
{
    #region [ References ]

    using ECharge.Car.Models;
    using HotChocolate.Types;

    #endregion

    public class CarType : ObjectType<Car>
    {
        #region [ Protected methods ]

        protected override void Configure(IObjectTypeDescriptor<Car> descriptor)
        {
            descriptor.Field(field => field.Id)
                .Type<NonNullType<IdType>>();
            descriptor.Field(field => field.Name)
                .Type<NonNullType<StringType>>();
            descriptor.Field(field => field.BatteryCapacity)
                .Type<NonNullType<ByteType>>();
        }

        #endregion
    }
}