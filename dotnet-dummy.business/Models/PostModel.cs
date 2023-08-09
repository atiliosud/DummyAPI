using System.ComponentModel.DataAnnotations;

namespace dotnet_dummy.business.Models
{
    public class PostModel
    {
        public PostModel()
        {
            PublishDate = DateTime.Now.ToString("M/d/yyyy");
            Likes = 0;
        }
        [MinLength(length: 6), MaxLength(length: 60)]
        public string? Id { get; set; }
        public string Text { get; set; }
        public string? Image { get; set; }
        public int? Likes { get; set; }
        public string? Link { get; set; }
        public string[] Tags { get; set; }
        public string PublishDate { get; set; }
    }
    public class PostModelCreate : PostModel
    {
        public string Owner { get; set; }
    }
    public class PostModelUpdate : PostModel { }
    public class PostModelList : PostModel
    {
        public UserModel Owner { get; set; }
    }
}