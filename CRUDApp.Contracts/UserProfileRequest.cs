using System.ComponentModel.DataAnnotations;

namespace CrudApp.Contracts
{
    public class UserProfileRequest
    {


        [Required()]
        public string Firstname { get; set; }

        [Required()]
        public string Lastname { get; set; }

        [MinLength(11)]
        [MaxLength(11)]
        public string PersonalNumber { get; set; }
    }


    public class UserProfileUpdateRequest
    {


        [Required()]
        public string Firstname { get; set; }

        [Required()]
        public string Lastname { get; set; }

        [MinLength(11)]
        [MaxLength(11)]
        public string PersonalNumber { get; set; }
    }
}
