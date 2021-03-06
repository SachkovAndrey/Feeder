﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Feeder.Common.Exceptions;
using Feeder.Core.Models;

namespace Feeder.ServiceClient
{
    public class PostServiceClient : IPostServiceClient
    {
        #region IPostServiceClient Members

        public async Task<Post> Get(string url)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return ResponseDeserializer.Deserialize<Post>(response);
                    case HttpStatusCode.InternalServerError:
                        throw new ConnectionTimeoutException(response.ReasonPhrase);
                    case HttpStatusCode.NotFound:
                        throw new NotSupportedException("EndPoint not found");
                    default:
                        throw new Exception(response.ReasonPhrase);
                }
            }
        }

        #endregion
    }
}
