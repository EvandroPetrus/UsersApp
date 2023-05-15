using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Tests.Helpers
{
    public static class TestHelper
    {
        /// <summary>
        /// Method made to create a http client on the users API.
        /// </summary>
        public static HttpClient CreateClient
            => new WebApplicationFactory<Program>().CreateClient();

        /// <summary>
        /// Method made to serialize the requisition content that will be sent to a service.
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static StringContent CreateContent<TRequest>(TRequest request)
            => new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");
        /// <summary>
        /// Method to deserialize the return obtained on the execution of a service.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static TResponse ReadResponse<TResponse>(HttpResponseMessage message)
            => JsonConvert.DeserializeObject<TResponse>(message.Content.ReadAsStringAsync().Result);
    }
}
