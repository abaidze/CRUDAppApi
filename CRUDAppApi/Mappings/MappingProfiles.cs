
using CrudApp.Contracts;
using CrudApp.Repository.Entities;

namespace CrudAppApi.Mappings
{

    public static class MappingProfiles
    {
        public static UserResponse UserToModel(this User user)
        {
            return new UserResponse()
            {
                Id = user.Id,
                Email = user.Email,
                IsActive = user.IsActive,
                Password = user.Password,
                Username = user.Username
            };
        }

        public static UserProfileResponse UserProfileToModel(this UserProfile profile)
        {
            return new UserProfileResponse()
            {
                Id = profile.Id,
                Firstname = profile.Firstname,
                Lastname = profile.Lastname,
                PersonalNumber = profile.PersonalNumber,
            };
        }


        public static User UserRequestToEntity(this UserRequest request)
        {

            return new User()
            {
                Email = request.Email,
                IsActive = request.IsActive,
                Password = request.Password,
                Username = request.Username,
                UserProfile = new UserProfile()
                {
                    Firstname = request.UserProfileRequest.Firstname,
                    Lastname = request.UserProfileRequest.Lastname,
                    PersonalNumber = request.UserProfileRequest.PersonalNumber,
                }
            };
        }
    }
}
