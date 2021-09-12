#region [ COPYRIGHT ]

// <copyright file="QueryType.cs" company="i-dentify Software Development">
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

namespace ECharge.Car.Api.GraphQl.Types
{
    #region [ References ]

    using ECharge.Car.Api.GraphQl;
    using HotChocolate.Types;

    #endregion

    public class QueryType : ObjectType<Query>
    {
        #region [ Protected methods ]

        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor
                .Field(field => field.GetCars(default))
                .Type<ListType<CarType>>();
        }

        #endregion
    }
}