#region [ COPYRIGHT ]

// <copyright file="MutationType.cs" company="i-dentify Software Development">
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

    using HotChocolate.Types;

    #endregion

    public class MutationType : ObjectType<Mutation>
    {
        #region [ Protected methods ]

        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(f => f.AddCar(default));
        }

        #endregion
    }
}