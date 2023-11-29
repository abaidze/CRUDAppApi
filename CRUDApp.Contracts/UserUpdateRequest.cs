using System.ComponentModel.DataAnnotations;

namespace CrudApp.Contracts
{
    public class UserUpdateRequest
    {
        public int Id { get; set; }

        [Required()]
        public string Password { get; set; }


        public bool IsActive { get; set; }

        public UserProfileUpdateRequest UserProfileRequest { get; set; }
    }
}
