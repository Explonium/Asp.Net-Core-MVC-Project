using System.Net.Http;
using System.Threading.Tasks;

namespace Mvc_Project_Client.Services
{
    public interface IRequestService
    {
        Task<T> DeserializeAsync<T>(HttpResponseMessage response);
        Task<HttpResponseMessage> SendRequestAsync(HttpMethod method, string address, object obj = null);
    }
}
