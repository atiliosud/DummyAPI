using dotnet_dummy.business.Enums;
using dotnet_dummy.business.Models;
using dotnet_dummy.business.Models.API;
using dotnet_dummy.business.Services.API;
using dotnet_dummy.business.Services.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace dotnet_dummy.business.Services
{
    public class PostService : IPostService
    {
        private readonly APIModel _APIModel;
        public PostService(APIModel APIModel)
        {
            _APIModel = APIModel;
        }

        public PostModelList Create(PostModelCreate obj)
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
                    $"post/create",
                    RequestTypeEnum.POST,
                    body: stringBody,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<PostModelList>
                                .Treat(returnApi);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PostModel Create(PostModel obj)
        {
            throw new NotImplementedException();
        }

        public string Delete(string id)
        {
            try
            {
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"post/{id}",
                    RequestTypeEnum.DELETE,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<PostModelUpdate>
                                .Treat(returnApi);

                if (result.Id != null)
                    return "Deleted successfull!";
                else
                    throw new Exception("Post can't be deleted!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PostModel GetById(string id)
        {
            try
            {
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"post/{id}",
                    RequestTypeEnum.GET,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<PostModelUpdate>
                                .Treat(returnApi);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PostModel> GetList(int page = 0, int limit = 20, string manyParameters = "")
        {
            try
            {
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"post?page={page}&limit={limit}{manyParameters}",
                    RequestTypeEnum.GET,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<List<PostModel>>
                                .Treat(returnApi);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PostModel> GetListByTag(string tagId, int page = 0, int limit = 20, string manyParameters = "")
        {
            try
            {
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"tag/{tagId}/post?page={page}&limit={limit}{manyParameters}",
                    RequestTypeEnum.GET,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<List<PostModel>>
                                .Treat(returnApi);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PostModel> GetListByUser(string userId, int page = 0, int limit = 20, string manyParameters = "")
        {
            try
            {
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"user/{userId}/post?page={page}&limit={limit}{manyParameters}",
                    RequestTypeEnum.GET,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<List<PostModel>>
                                .Treat(returnApi);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PostModelList Update(PostModelUpdate obj, string id)
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
                    $"post/{id}",
                    RequestTypeEnum.PUT,
                    body: stringBody,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<PostModelList>
                                .Treat(returnApi);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PostModel Update(PostModel obj, string id)
        {
            throw new NotImplementedException();
        }
    }
}
