using dotnet_dummy.business.Enums;
using dotnet_dummy.business.Models.API;
using dotnet_dummy.business.Services.API;
using dotnet_dummy.business.Services.Contracts;

namespace dotnet_dummy.business.Services
{
    public class TagService : ITagService
    {
        private readonly APIModel _APIModel;
        public TagService(APIModel APIModel)
        {
            _APIModel = APIModel;
        }

        public string[] GetList(int page = 0, int limit = 20)
        {
            try
            {
                var returnApi = APIConnectService.ConnectToService(
                    _APIModel.BaseUrl,
                    $"tag?page={page}&limit={limit}",
                    RequestTypeEnum.GET,
                    bodyType: "application/json",
                    appId: _APIModel.AppId
                );

                var result = TreatResult<string[]>
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
