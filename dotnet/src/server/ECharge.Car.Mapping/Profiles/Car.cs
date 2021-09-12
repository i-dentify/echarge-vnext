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

namespace ECharge.Car.Mapping.Profiles
{
    #region [ References ]

    using System;
    using AutoMapper;
    using ECharge.Car.Events;
    using ECharge.Car.Models.Input;

    #endregion

    public class Car : Profile
    {
        #region [ Constructor ]

        public Car()
        {
            this.MapInputsToEvents();
        }

        #endregion

        #region [ Private methods ]

        private void MapInputsToEvents()
        {
            this.CreateMap<AddCar, CarAdded>()
                .ForMember(target => target.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        }

        #endregion
    }
}