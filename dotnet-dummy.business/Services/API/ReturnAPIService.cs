using dotnet_dummy.business.Models.API;
using dotnet_dummy.business.Models.Base;
using Microsoft.AspNetCore.Connections.Features;
using Newtonsoft.Json;

namespace dotnet_dummy.business.Services.API
{
    public class ReturnAPIService<T>
    {
        public object TreatReturn(HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage.StatusCode.Equals(System.Net.HttpStatusCode.BadRequest))
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var objBaseError = JsonConvert.DeserializeObject<BadRequest>(result);
                var objBadRequest = JsonConvert.DeserializeObject<BaseError>(result);
                if (objBadRequest.GenericMessage is null)
                    return new BaseError { GenericMessage = objBaseError.Errors?.ToString(), GenericNumber = (int)httpResponseMessage.StatusCode, Message = objBaseError.Title };
                else
                    return objBadRequest;
            }
            if (httpResponseMessage.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized) || httpResponseMessage.StatusCode.Equals(System.Net.HttpStatusCode.NotFound))
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                return new BaseError { GenericMessage = httpResponseMessage.RequestMessage.ToString(), GenericNumber = (int)httpResponseMessage.StatusCode, Message = result.ToString() };
            }
            var resultContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            var convertjson = JsonConvert.DeserializeObject<ReturnAPIServiceModel<T>>(resultContent.ToString());
            if (convertjson != null)
            {
                if (convertjson.Data == null)
                {
                    //it is not a collection..
                    //then, try to convert the result to a single type of <T>
                    var convertSingleJson = JsonConvert.DeserializeObject<T>(resultContent.ToString());

                    return new BaseResult<T>
                    {
                        Message = "Get list successfull!",
                        Result = convertSingleJson
                    };
                }

                return new BaseResult<T>
                {
                    Message = "Get list successfull!",
                    Result = convertjson.Data
                };
            }
            else if (JsonConvert.DeserializeObject<BaseError>(httpResponseMessage.ToString()) is BaseError)
            {
                BaseError baseErrorModel = JsonConvert.DeserializeObject<BaseError>(resultContent);
                return baseErrorModel;
            }
            else
            {
                return httpResponseMessage.ToString();
            }
        }
        public object TreatReturnFile(HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage.StatusCode.Equals(System.Net.HttpStatusCode.BadRequest))
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var objBaseError = JsonConvert.DeserializeObject<BadRequest>(result);
                var objBadRequest = JsonConvert.DeserializeObject<BaseError>(result);
                if (objBadRequest.GenericMessage is null)
                    return new BaseError { GenericMessage = objBaseError.Errors.ToString(), GenericNumber = (int)httpResponseMessage.StatusCode, Message = objBaseError.Title };
                else
                    return objBadRequest;
            }
            if (httpResponseMessage.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized) || httpResponseMessage.StatusCode.Equals(System.Net.HttpStatusCode.NotFound))
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                return new BaseError { GenericMessage = httpResponseMessage.RequestMessage.ToString(), GenericNumber = (int)httpResponseMessage.StatusCode, Message = result.ToString() };
            }
            var resultContent = httpResponseMessage.Content.ReadAsByteArrayAsync().Result;
            return resultContent;
        }
    }

}
