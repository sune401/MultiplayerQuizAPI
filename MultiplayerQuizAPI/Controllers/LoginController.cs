using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MultiplayerQuizAPI.models;
using MultiplayerQuizAPI.Services;
using LoginRequest = MultiplayerQuizAPI.models.LoginRequest;

namespace MultiplayerQuizAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly TokenService _tokenService;
        
        public LoginController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult login([FromBody] LoginRequest loginRequest)
        {
            if(loginRequest.username == "admin" && loginRequest.password == "1234")
            {
                var token = _tokenService.CreateToken(loginRequest.username);

                return Ok(new LoginResponse
                {
                    token = token,
                });
            }
            return Unauthorized();
            
        }
    }
}
