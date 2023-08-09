using dotnet_dummy.business.Enums;
using dotnet_dummy.business.Models.Base;
using System.Text;

namespace dotnet_dummy.business.Services.API
{
    public static class APIConnectService
    {
        public static object ConnectToService(string url, string endPoint, RequestTypeEnum requestType, string appId = "", string body = null, string bodyType = null)
        {
            try
            {
                HttpClient client = new HttpClient();
                if (!string.IsNullOrEmpty(appId))
                {
                    client.DefaultRequestHeaders.Add("app-id", appId);
                    client.DefaultRequestHeaders.Accept.Clear();
                }
                client.BaseAddress = new Uri(url);
                var result = string.Empty;
                StringContent stringContent;
                switch (requestType)
                {
                    case RequestTypeEnum.GET:
                        {
                            if (body != null)
                            {
                                return client.GetAsync(endPoint).Result;
                            }
                            else
                                return client.GetAsync(endPoint).Result;
                        }
                    case RequestTypeEnum.POST:
                        {
                            stringContent = new StringContent(body, Encoding.UTF8, bodyType);
                            return client.PostAsync(endPoint, stringContent).Result;
                        }
                    case RequestTypeEnum.PUT:
                        {
                            stringContent = new StringContent(body, Encoding.UTF8, bodyType);
                            return client.PutAsync(endPoint, stringContent).Result;
                        }
                    case RequestTypeEnum.DELETE:
                        {
                            var returnRequest = client.DeleteAsync(endPoint).Result;
                            result = returnRequest.Content.ReadAsStringAsync().Result;
                            return returnRequest;
                            break;
                        }
                    default:
                        break;
                }
                return null;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            catch (Exception e)
            {
                BaseError baseErrorModel = new BaseError { GenericMessage = "Requisição inválida.", Message = e.InnerException.Message };
                return baseErrorModel;
            }
        }
    }
}
