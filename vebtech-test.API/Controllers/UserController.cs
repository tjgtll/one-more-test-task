using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using vebtech_test.BLL.Services;
using vebtech_test.BLL.Services.IServices;
using vebtech_test.BLL.Utilites.Exeptions;
using vebtech_test.DTO;

namespace vebtech_test.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private const string _badRequestMessage = "Something went wrong\n{0}";
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getusers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [SwaggerOperation("Get a list of users.")]
        public IActionResult GetUsers(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string sortBy = "Name",
        [FromQuery] string sortOrder = "asc",
        [FromQuery] string filterByName = "",
        [FromQuery] string filterByRole = "")
        {
            try
            {
                var result = _userService.GetUsers(page, pageSize, sortBy, sortOrder, filterByName, filterByRole);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(_badRequestMessage, ex.Message));
            }
        }

        [HttpGet("getuser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [SwaggerOperation("Get a user by Id.")]
        public IActionResult GetUser(string userId)
        {
            try
            {
                return Ok(_userService.GetUser(userId));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.UserId);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(_badRequestMessage, ex.Message));
            }
        }

        [HttpPost("adduser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [SwaggerOperation("Add a new user.")]
        public IActionResult AddUser(UserToAddDTO userToAddDTO)
        {
            try
            {
                _userService.AddUser(userToAddDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(_badRequestMessage, ex.Message));
            }
        }

        [HttpPost("adduserrole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [SwaggerOperation("Add a role to a user.")]
        public IActionResult AddUserRole(string userId, string roleId)
        {
            try
            {
                _userService.AddUserRole(userId, roleId);
                return Ok();
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.UserId);
            }
            catch (RoleNotFoundException ex)
            {
                return NotFound(ex.RoleId);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(_badRequestMessage, ex.Message));
            }
        }

        [HttpPut("updateuser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [SwaggerOperation("Update user information by Id.")]
        public IActionResult UpdateUser( UserToUpdateDTO userToUpdateDTO)
        {
            try
            {
                return Ok(_userService.UpdateUser(userToUpdateDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(_badRequestMessage, ex.Message));
            }
        }

        [HttpDelete("deleteuser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [SwaggerOperation("Delete a user by Id.")]
        public IActionResult DeleteUser(string userId)
        {
            try
            {
                _userService.DeleteUser(userId);
                return Ok();
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.UserId);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(_badRequestMessage, ex.Message));
            }
        }
    }
}
