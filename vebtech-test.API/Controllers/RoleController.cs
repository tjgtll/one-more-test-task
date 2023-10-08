using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using vebtech_test.BLL.Services.IServices;
using vebtech_test.BLL.Utilites.Exeptions;
using vebtech_test.DTO;

namespace vebtech_test.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private const string _badRequestMessage = "Something went wrong\n{0}";
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("getroles")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RoleDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [SwaggerOperation("Get all roles")] 
        public IActionResult GetRoles()
        {
            try
            {
                return Ok(_roleService.GetRoles());
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(_badRequestMessage, ex.Message));
            }
        }

        [HttpGet("getrole")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [SwaggerOperation("Get role by Id")]
        public IActionResult GetRole(string roleId)
        {
            try
            {
                return Ok(_roleService.GetRole(roleId));
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

        [HttpPost("addrole")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [SwaggerOperation("Add a new role")]
        public IActionResult AddRole(RoleToAddDTO roleToAddDTO)
        {
            try
            {
                _roleService.AddRole(roleToAddDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(_badRequestMessage, ex.Message));
            }
        }
    }
}
