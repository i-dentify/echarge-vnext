#region [ COPYRIGHT ]

// <copyright file="IQuery.cs" company="i-dentify Software Development">
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

namespace ECharge.Core.Data.Query.Interfaces
{
    #region [ References ]

    using System.Threading;
    using System.Threading.Tasks;

    #endregion

    public interface IQuery<TResult>
    {
        #region [ Methods ]

        Task<TResult> ExecuteAsync(CancellationToken cancellationToken = default);

        #endregion
    }

    public interface IQuery<TResult, in TParams> where TParams : IQueryParameters
    {
        #region [ Methods ]

        Task<TResult> ExecuteAsync(TParams parameters, CancellationToken cancellationToken = default);

        #endregion
    }
}