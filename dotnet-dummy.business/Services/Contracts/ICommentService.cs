using dotnet_dummy.business.Models;

namespace dotnet_dummy.business.Services.Contracts
{
    public interface ICommentService : IBaseService<CommentModel>
    {
        CommentModel Create(CommentModelCreate comment);
        List<CommentModel> GetListByUser(string userId, int page = 0, int limit = 20, string manyParameters = "");
        List<CommentModel> GetListByPost(string postId, int page = 0, int limit = 20, string manyParameters = "");
    }
}
