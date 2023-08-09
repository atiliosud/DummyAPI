namespace dotnet_dummy.business.Models
{
    public class CommentModel
    {
        public CommentModel()
        {
            PublishDate = DateTime.Now.ToString("M/d/yyyy");
        }
        public string Id { get; set; }
        public string Message { get; set; }
        public UserModel Owner { get; set; }
        public string Post { get; set; }
        public string PublishDate { get; set; }
    }
    public class CommentModelCreate
    {
        public string Message { get; set; }
        public string Owner { get; set; }
        public string Post { get; set; }
    }
}