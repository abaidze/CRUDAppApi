using System.ComponentModel.DataAnnotations;

namespace CrudApp.Contracts
{
    public class UserRequest
    {
        public int? Id { get; set; }


        [Required()]
        public string Username { get; set; }

        [Required()]
        public string Password { get; set; }

        [Required()]
        public string Email { get; set; }

        public bool IsActive { get; set; }

        public UserProfileRequest UserProfileRequest { get; set; }
    }
}
