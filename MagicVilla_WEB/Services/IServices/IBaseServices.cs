using MagicVilla_WEB.Models;

namespace MagicVilla_WEB.Services.IServices
{
    public interface IBaseServices
    {
        APIResponse responseModel { get; set; }

        Task<T> SendAsync<T>(APIRequest apiRequest);

    }
}
