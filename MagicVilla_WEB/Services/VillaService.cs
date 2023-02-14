using MagicVilla_Utility;
using MagicVilla_WEB.Models;
using MagicVilla_WEB.Models.DTO;
using MagicVilla_WEB.Services.IServices;

namespace MagicVilla_WEB.Services
{
    public class VillaService :BaseServices, IVillaService 
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaUrl;

        public VillaService(IHttpClientFactory clientFactory,IConfiguration configur) :base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaUrl = configur.GetValue<string>("ServiceUrls:VillaAPI");

		}

        public Task<T> CreateAsync<T>(VillaCreateDTO dto)
        {
           return SendAsync<T>(new APIRequest()
            {

                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = villaUrl + "/api/APIController"
            });
        }
        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url=villaUrl+"/api/APIController/"+id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest() 
            {
                ApiType=SD.ApiType.GET,

                Url=villaUrl+"/api/APIController"
            });
        }

        public Task<T> GetAync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaUrl + "/api/APIController" + id
            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = villaUrl + "/api/APIController/" +dto.Id
            });
        }
    }
}
