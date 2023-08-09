using dotnet_dummy.business.Models;

namespace dotnet_dummy.business.Services.Contracts
{
    public interface ITagService
    {
        public string[] GetList(int page = 0, int limit = 20);
    }
}
