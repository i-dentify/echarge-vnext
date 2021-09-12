#region [ COPYRIGHT ]

// <copyright file="CollectionAttribute.cs" company="i-dentify Software Development">
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

namespace ECharge.Data.Entities.MongoDB.Attributes
{
    #region [ References ]

    using System;

    #endregion

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CollectionAttribute : Attribute
    {
        public CollectionAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}