using Microsoft.AspNetCore.Mvc;
using FantasyStock.Data;
using FantasyStock.Models;
using FantasyStock.Dtos.User;


namespace FantasyStock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthControllers : ControllerBase
    {
        private  readonly IAuthRepository _authRepo;

        public AuthControllers(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepo.Register(
                new User { Username = request.Username }, request.Password
                );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _authRepo.Login(request.Username, request.Password);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
