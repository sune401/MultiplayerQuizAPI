using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiplayerQuizAPI.DB;
using MultiplayerQuizAPI.models;

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
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(x => x.email == request.Email);

            if (existingUser != null)
            {
                return BadRequest("User already exists");
            }


            var user = new User
            {
                username = request.Email,
                email = request.Email,
                passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            };


            _context.Users.Add(user);

            await _context.SaveChangesAsync();


            return Ok(new
            {
                message = "User created"
            });
        }
    }
}
