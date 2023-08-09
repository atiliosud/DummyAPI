using dotnet_dummy.business.Enums;
using dotnet_dummy.business.Models;
using dotnet_dummy.business.Models.API;
using dotnet_dummy.business.Services.API;
using dotnet_dummy.business.Services.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace dotnet_dummy.business.Services
{
    public class CommentService : ICommentService
    {
        private readonly APIModel _APIModel;
        public CommentService(APIModel APIModel)
        {
            _APIModel = APIModel;
        }

        public CommentModel Create(CommentModelCreate obj)
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
                    $"comment/create",
                    RequestTypeEnum.POST,
                    body: stringBody,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<CommentModel>
                                .Treat(returnApi);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CommentModel Create(CommentModel obj)
        {
            throw new NotImplementedException();
        }

        public string Delete(string id)
        {
            try
            {
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"comment/{id}",
                    RequestTypeEnum.DELETE,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<CommentModel>
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

        public CommentModel GetById(string id)
        {
            try
            {
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"comment/{id}",
                    RequestTypeEnum.GET,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<CommentModel>
                                .Treat(returnApi);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CommentModel> GetList(int page = 0, int limit = 20, string manyParameters = "")
        {
            try
            {
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"comment?page={page}&limit={limit}{manyParameters}",
                    RequestTypeEnum.GET,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<List<CommentModel>>
                                .Treat(returnApi);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CommentModel> GetListByPost(string postId, int page = 0, int limit = 20, string manyParameters = "")
        {
            try
            {
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"post/{postId}/comment?page={page}&limit={limit}{manyParameters}",
                    RequestTypeEnum.GET,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<List<CommentModel>>
                                .Treat(returnApi);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CommentModel> GetListByUser(string userId, int page = 0, int limit = 20, string manyParameters = "")
        {
            try
            {
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"user/{userId}/comment?page={page}&limit={limit}{manyParameters}",
                    RequestTypeEnum.GET,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<List<CommentModel>>
                                .Treat(returnApi);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CommentModel Update(CommentModel obj, string id)
        {
            throw new NotImplementedException();
        }
    }
}
