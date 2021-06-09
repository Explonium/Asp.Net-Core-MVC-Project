using Marvin.StreamExtensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Project_Client.Services
{
    public class RequestService : IRequestService
    {
        private static HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public RequestService(IConfiguration configuration)
        {
            _configuration = configuration;

            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri(_configuration["ApiUrl"]);
                _httpClient.Timeout = new TimeSpan(0, 0, 30);
                _httpClient.DefaultRequestHeaders.Clear();
            }
        }

        public async Task Delete(string path, string id)
        {
            await SendRequestAsync(HttpMethod.Delete, _configuration["Routes:" + path] + id);
        }

        public async Task<T> DeserializeAsync<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            return stream.ReadAndDeserializeFromJson<T>();
        }

        public async Task<T> Get<T>(string path, string id = "")
        {
            var response = await SendRequestAsync(HttpMethod.Get, _configuration["Routes:" + path] + id);
            return await DeserializeAsync<T>(response);
        }

        public async Task<ICollection<T>> GetList<T>(string path)
        {
            var response = await SendRequestAsync(HttpMethod.Get, _configuration["Routes:" + path]);
            return await DeserializeAsync<List<T>>(response);
        }

        public async Task<T> Post<T>(string path, T obj)
        {
            var response = await SendRequestAsync(HttpMethod.Post, _configuration["Routes:" + path], obj);
            return await DeserializeAsync<T>(response);
        }

        public async Task Put<T>(string path, T obj, string id)
        {
            await SendRequestAsync(HttpMethod.Put, _configuration["Routes:" + path] + id, obj);
        }

        public async Task<HttpResponseMessage> SendRequestAsync(HttpMethod method, string address, object obj = null)
        {
            var request = new HttpRequestMessage(method, address);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = null;

            // Writing object into content as json if it exists
            if (obj != null)
            {
                var memoryContentStream = new MemoryStream();
                memoryContentStream.SerializeToJsonAndWrite(obj, new UTF8Encoding(), 1024, true);
                memoryContentStream.Seek(0, SeekOrigin.Begin);

                using (var streamContent = new StreamContent(memoryContentStream))
                {
                    request.Content = streamContent;
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // Sending request and checking response
                    response = await _httpClient.SendAsync(request);
                }
            }
            else
                response = await _httpClient.SendAsync(request);

            var headers = Enumerable.ToDictionary(response.Headers, h_ => h_.Key, h_ => h_.Value);
            if (response.Content != null && response.Content.Headers != null)
            {
                foreach (var item_ in response.Content.Headers)
                    headers[item_.Key] = item_.Value;

            }

            var status = (int)response.StatusCode;
            if (status != 200 && status != 201 && status != 204 && status != 206)
            {
                var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                //throw new Exception(responseData);
                throw new ApiException("The HTTP status code of the response was not expected (" + status + ").", status, responseData, headers, null);
            }

            return response;
        }
    }
}