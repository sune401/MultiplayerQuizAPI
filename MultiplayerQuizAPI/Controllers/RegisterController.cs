using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiplayerQuizAPI.DB;
using MultiplayerQuizAPI.models;
using RegisterRequest = MultiplayerQuizAPI.models.RegisterRequest;

namespace MultiplayerQuizAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegisterController(AppDbContext appDbContext)
        {
            _context = appDbContext;    
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if(await _context.Users.AnyAsync(u => u.username == request.username))
            {
                return BadRequest("Username already exists.");
            }

            if(await _context.Users.AnyAsync(u => u.email == request.email))
            {
                return BadRequest("Email already exists.");
            }

            var user = new User
            {
                username = request.username,
                email = request.email,
                firstName = request.firstName,
                lastName = request.lastName,
                passwordHash = BCrypt.Net.BCrypt.HashPassword(request.password),
                phoneNumber = request.phoneNumber

            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }
    }
}
