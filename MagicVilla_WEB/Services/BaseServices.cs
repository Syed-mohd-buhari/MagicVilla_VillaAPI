using MagicVilla_Utility;
using MagicVilla_WEB.Models;
using MagicVilla_WEB.Services.IServices;
using Newtonsoft.Json;
using System.Text;

namespace MagicVilla_WEB.Services
{
    public class BaseServices : IBaseServices
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; } 
        public BaseServices(IHttpClientFactory httpClient) 
        {
            this.responseModel = new();
            this.httpClient = httpClient;  
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {

                var Client = httpClient.CreateClient("MagicAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);

                if (apiRequest.Data!= null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8,"application/json");
                }
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                HttpResponseMessage apiResponse = null;

                apiResponse = await Client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);

                return APIResponse;


            }
            catch (Exception e) 
            {
                var _error = new APIResponse
                {
                    ErrorMessage = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };
                var _result = JsonConvert.SerializeObject(_error);
                var APIResponce = JsonConvert.DeserializeObject<T>(_result);
                return APIResponce;
            }
        }
    }
}
