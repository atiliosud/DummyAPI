using dotnet_dummy.business.Utils;
using System.ComponentModel.DataAnnotations;

namespace dotnet_dummy.business.Models
{
    public class UserModel
    {
        public UserModel()
        {
            DateOfBirth = DateTime.Now.ToString("M/d/yyyy");
            RegisterDate = DateTime.Now.ToString("M/d/yyyy");

            //creates a list of titles
            var alternatives = new List<(string, string)>()
            {
                ("", "other"),
                ("mr", "male"),
                ("ms", "female"),
                ("miss", "female"),
                ("dr", "male")
            };

            var titleAndGender = alternatives.PickRandom();

            Title = titleAndGender.Item1;
            Gender = titleAndGender.Item2;
        }

        public string? Id { get; set; }
        public string? Title { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? Gender { get; set; }
        public string? Email { get; set; }

        public string? DateOfBirth { get; set; }
        public string? RegisterDate { get; set; }
        public string? Phone { get; set; }
        public string? Picture { get; set; }
        public LocationModel? Location { get; set; }
    }
}