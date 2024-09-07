using Microsoft.AspNetCore.Mvc;
using Task_Management_App_V2.DTO;
using Task_Management_App_V2.Interfaces;
using Task_Management_App_V2.Models;

namespace Task_Management_App_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;

        public AuthController(IAuthService authService, IAuthRepository authRepository, IJwtService jwtService)
        {
            _authService = authService;
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        [HttpPost("create-user", Name = "CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO request)
        {
            try
            {
                UserModel user = new UserModel();
                user.UserId = Guid.NewGuid().ToString();
                user.UserName = request.UserName;
                user.Email = request.Email;
                user.Role = request.Role;
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
                //user.PasswordHash = request.Password;

                var result = await _authService.CreateUser(user);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Created(string.Empty,"User created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login-user", Name = "LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO request)
        {
            try
            {
                var userResult = await _authRepository.FindUserByEmail(request.Email);
                if (!userResult.Status)
                {
                    return BadRequest(userResult);
                }
                UserModel user = userResult.Data as UserModel;

                bool verified = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
                if (!verified)
                    //if (!(request.Password == user.PasswordHash))
                {
                    return BadRequest(new GeneralResponseInternalDTO(false, "Incorrect Password"));
                }

                var result = await _jwtService.GenerateJwt(user);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(new GeneralResponseInternalDTO(true, result.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
