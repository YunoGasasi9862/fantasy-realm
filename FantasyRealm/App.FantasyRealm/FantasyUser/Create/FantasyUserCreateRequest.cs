using Core.App.Features;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.FantasyRealm.FantasyUser.Create
{
    public class FantasyUserCreateRequest: CommandRequest, IRequest<CommandResponse>
    {
        public FantasyUserCreateRequest() { }

        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Date)] //this is amazing - lets you annotation with a specific data type for business logic (for display purposes), and then we can put regular expressions/validation to grab the data in a specific format
        [RegularExpression(@"\d{4}-\d{2}-\d{2}", ErrorMessage = "DateOfBirth must be in the format yyyy-mm-dd")]
        public string DateOfBirth { get; set; }

        //Path
        [DataType(DataType.ImageUrl)]
        public string ProfilePicturePath { get; set; }
    }
}
