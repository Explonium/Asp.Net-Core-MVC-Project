using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mvc_Project_Client.Services
{
    public interface IRequestService
    {
        Task<T> DeserializeAsync<T>(HttpResponseMessage response);
        Task<HttpResponseMessage> SendRequestAsync(HttpMethod method, string address, object obj = null);
        Task<ICollection<T>> GetList<T>(string path);
        Task<T> Get<T>(string path, string id = "");
        Task<T> Post<T>(string path, T obj);
        Task Put<T>(string path, T obj, string id = "");
        Task Delete(string path, string id = "");
    }
}
