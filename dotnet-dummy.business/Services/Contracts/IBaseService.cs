namespace dotnet_dummy.business.Services.Contracts
{
    public interface IBaseService<T>
    {
        List<T> GetList(int page = 0, int limit = 20, string manyParameters = "");
        T GetById(string id);
        T Create(T obj);
        T Update(T obj, string id);
        string Delete(string id);
    }
}
