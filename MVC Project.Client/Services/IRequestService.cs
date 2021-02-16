using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVC_Project.Client.Services
{
    public interface IRequestService
    {
        Task<T> DeserializeAsync<T>(HttpResponseMessage response);
        Task<HttpResponseMessage> SendRequestAsync(HttpMethod method, string address, object memoryStream = null);
    }
}
