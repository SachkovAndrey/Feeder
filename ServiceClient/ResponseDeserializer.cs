using System.Net.Http;
using Newtonsoft.Json;

namespace Feeder.ServiceClient
{
    internal static class ResponseDeserializer
    {
        #region Static Methods

        internal static T Deserialize<T>(HttpResponseMessage responseMessage)
        {
            string strJson = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(strJson);
        }

        #endregion
    }
}
