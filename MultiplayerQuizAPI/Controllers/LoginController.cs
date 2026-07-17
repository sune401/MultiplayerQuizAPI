using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiplayerQuizAPI.DB;
using MultiplayerQuizAPI.models;
using MultiplayerQuizAPI.Services;
using System.Threading.Tasks;
using LoginRequest = MultiplayerQuizAPI.models.LoginRequest;

namespace MultiplayerQuizAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly TokenService _tokenService;
        
        public LoginController(TokenService tokenService, AppDbContext appDbContext)
        {
            _context = appDbContext;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> login([FromBody] LoginRequest loginRequest)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.username == loginRequest.username);

            if(user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            bool validPassword = BCrypt.Net.BCrypt.Verify(loginRequest.password, user.passwordHash);
            if(!validPassword)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            var token = _tokenService.CreateToken(user);
            return Ok(new { token = token });

        }
    }
}
