#region [ COPYRIGHT ]

// <copyright file="ContainerBuilderExtensions.cs" company="i-dentify Software Development">
// Copyright (c) 2021 i-dentify Software Development (http://www.i-dentify.de) - All Rights Reserved.
// 
// Unauthorized copying of this file, via any medium is strictly prohibited.
// Proprietary and confidential.
// 
// </copyright>
// <author>Mario Adam</author>
// <email>mail@i-dentify.de</email>
// <date>2021-09-09</date>
// <summary></summary>

#endregion

namespace ECharge.Car.Query.Extensions
{
    #region [ References ]

    using Autofac;
    using ECharge.Car.Query.Queries;
    using ECharge.Car.Query.Queries.Interfaces;

    #endregion

    public static class ContainerBuilderExtensions
    {
        #region [ Public methods ]

        public static ContainerBuilder RegisterQueries(this ContainerBuilder builder)
        {
            builder.RegisterType<AllCars>()
                .As<IAllCars>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CarWithNameDoesNotExist>()
                .As<ICarWithNameDoesNotExist>()
                .InstancePerLifetimeScope();
            return builder;
        }

        #endregion
    }
}