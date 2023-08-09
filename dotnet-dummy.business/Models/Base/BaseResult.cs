namespace dotnet_dummy.business.Models.Base
{
    public class BaseResult<T>
    {
        public string Message { get; set; }
        public T Result { get; set; }
    }
}