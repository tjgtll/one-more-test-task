//using Microsoft.AspNetCore.Mvc;
//using vebtech_test.BLL.Services;
//using vebtech_test.BLL.Services.IServices;
//using vebtech_test.DTO;

//namespace vebtech_test.API.Controllers
//{
//    [ApiController]
//    [Route("api/auth")]
//    public class AuthController : Controller
//    {
//        private readonly IConfiguration _configuration;
//        private readonly IJwtService _jwtService;
//        public AuthController(IConfiguration configuration, IJwtService jwtService)
//        {
//            _configuration = configuration;
//            _jwtService = jwtService;
//        }

//        [HttpPost("login")]
//        public IActionResult Login([FromBody] LoginRequestDTO model)
//        {
//            if (model.Username == "admin" && model.Password == "admin")
//            {
//                var token = _jwtService.Login();
//                return Ok(new { Token = token });
//            }

//            return Unauthorized(new { Message = "Invalid credentials" });
//        }
//    }
//}
