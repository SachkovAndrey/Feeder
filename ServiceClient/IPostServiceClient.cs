﻿using System.Threading.Tasks;
using Feeder.Core.Models;

namespace Feeder.ServiceClient
{
    public interface IPostServiceClient
    {
        #region Methods

        Task<Post> Get(string url);

        #endregion
    }
}
