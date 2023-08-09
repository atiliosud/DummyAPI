using dotnet_dummy.business.Models.API;
using dotnet_dummy.business.Models.Base;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace dotnet_dummy.business.Services.API
{
    public static class TreatResult<T>
    {
        public static T Treat(object? obj)
        {
            if (obj is HttpResponseMessage message)
            {
                var APIService = new ReturnAPIService<T>();
                var result = APIService.TreatReturn(message);
                if (result is BaseResult<T> baseResult)
                {
                    if (!string.IsNullOrEmpty(baseResult.Message))
                        return baseResult.Result;
                    else
                        throw new Exception(JsonConvert.SerializeObject(baseResult));
                }
                else
                    throw new Exception(JsonConvert.SerializeObject(result));
            }
            else
                throw new Exception(JsonConvert.SerializeObject(obj));
        }
    }
}
