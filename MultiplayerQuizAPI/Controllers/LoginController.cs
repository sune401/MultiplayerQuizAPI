using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MultiplayerQuizAPI.models;
using LoginRequest = MultiplayerQuizAPI.models.LoginRequest;

namespace MultiplayerQuizAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public LoginResponse login([FromBody] LoginRequest loginRequest)
        {
            Console.WriteLine($"Username: {loginRequest.username}, Password: {loginRequest.password}");

            var response = new LoginResponse();
            response.username = loginRequest.username;
            response.success = true;
            response.token = "dmdlkmndvlndvxnvvnfjfdbf";

            if (loginRequest.username == "admin" && loginRequest.password == "1234")
            {
                return response;
            }

            return null;
        }
    }
}
