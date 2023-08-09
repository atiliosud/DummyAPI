namespace dotnet_dummy.business.Models.API
{
    public class BadRequest
    {
        public object Errors { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string TraceId { get; set; }
    }
}