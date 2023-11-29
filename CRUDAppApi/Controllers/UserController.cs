using CrudApp.Contracts;
using CrudApp.Core;
using CrudApp.Repository.Entities;
using CrudAppApi.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudAppApi.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;


        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        [Route("Users")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserResponse>))]
        public IActionResult GetUsers()
        {
            var usersData = new List<UserResponse>();

            var users = _userRepository.GetUsers();

            if (users.Any())
            {
                foreach (var user in users)
                {

                    var userModel = user.UserToModel();

                    var profile = _userRepository.GetUserProfile(user.Id);

                    if (profile != null)
                    {
                        userModel.UserProfileResponse = profile.UserProfileToModel();
                    }

                    usersData.Add(userModel);
                }
            }

            return Ok(usersData);
        }


        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int userId)
        {
            if (!_userRepository.UserExists(userId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _userRepository.GetUser(userId);

            if (user != null)
            {

                var userModel = user.UserToModel();

                var profile = _userRepository.GetUserProfile(user.Id);

                if (profile != null)
                {
                    userModel.UserProfileResponse = profile.UserProfileToModel();
                }

                return Ok(userModel);
            }

            return BadRequest("მომხმარებელი ვერ მოიძებნა");
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            var user = _userRepository.GetUsers()
                .Where(c => c.Username.Trim().ToUpper() == request.Username.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "user already exists");
                return StatusCode(422, ModelState);
            }


            var isRegistered = _userRepository.CreateUser(request.UserRequestToEntity());

            if (isRegistered)
            {
                return Ok("Successfully created");
            }

            return BadRequest("Try again. Uesr not registered!");
        }



        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]//aq co put unda iyos
        [ProducesResponseType(404)]
        public IActionResult UpdateUser([FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();



            if (request.Id <= 0)
            {
                return BadRequest("User id is inncorect");
            }

            var userId = request.Id;

            if (!_userRepository.UserExists(userId))
                return NotFound();

            var user = _userRepository.GetUser(userId);

            user.Password = request.Password;
            user.IsActive = request.IsActive;


            if (request.UserProfileRequest == null)
            {

                return BadRequest("User profile info is required");
            }


            var profile = _userRepository.GetUserProfile(userId);
            user.UserProfile = profile;

            user.UserProfile.Firstname = request.UserProfileRequest.Firstname;
            user.UserProfile.Lastname = request.UserProfileRequest.Lastname;
            user.UserProfile.PersonalNumber = request.UserProfileRequest.PersonalNumber;


            _userRepository.UpdateUser(user);
            _userRepository.Save();


            return Ok();
        }


        [HttpDelete("{userId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int userId)
        {
            if (!_userRepository.UserExists(userId))
            {
                return NotFound();
            }

            var userToDelete = _userRepository.GetUser(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userRepository.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting user");
            }

            return NoContent();
        }

    }
}
