using dotnet_dummy.business.Models;

namespace dotnet_dummy.business.Services.Contracts
{
    public interface IPostService : IBaseService<PostModel>
    {
        PostModelList Create(PostModelCreate postModel);
        PostModelList Update(PostModelUpdate postModel, string id);
        List<PostModel> GetListByUser(string userId, int page = 0, int limit = 20, string manyParameters = "");
        List<PostModel> GetListByTag(string tagId, int page = 0, int limit = 20, string manyParameters = "");
    }
}
