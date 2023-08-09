using dotnet_dummy.business.Enums;
using dotnet_dummy.business.Models;
using dotnet_dummy.business.Models.API;
using dotnet_dummy.business.Services.API;
using dotnet_dummy.business.Services.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace dotnet_dummy.business.Services
{
    public class UserService : IUserService
    {
        private readonly APIModel _APIModel;
        public UserService(APIModel APIModel)
        {
            _APIModel = APIModel;
        }

        public UserModel Create(UserModel obj)
        {
            try
            {
                var stringBody = JsonConvert.SerializeObject(obj,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"user/create",
                    RequestTypeEnum.POST,
                    body: stringBody,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<UserModel>
                                .Treat(returnApi);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Delete(string id)
        {
            try
            {
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"user/{id}",
                    RequestTypeEnum.DELETE,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<UserModel>
                                .Treat(returnApi);

                if (result.Id != null)
                    return "Deleted successfull!";
                else
                    throw new Exception("User can't be deleted!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserModel GetById(string id)
        {
            try
            {
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"user/{id}",
                    RequestTypeEnum.GET,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<UserModel>
                                .Treat(returnApi);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UserModel> GetList(int page = 0, int limit = 20, string manyParameters = "")
        {
            try
            {
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"user?page={page}&limit={limit}{manyParameters}",
                    RequestTypeEnum.GET,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<List<UserModel>>
                                .Treat(returnApi);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserModel Update(UserModel obj, string id)
        {
            try
            {
                var stringBody = JsonConvert.SerializeObject(obj,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"user/{id}",
                    RequestTypeEnum.PUT,
                    body: stringBody,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<UserModel>
                                .Treat(returnApi);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
