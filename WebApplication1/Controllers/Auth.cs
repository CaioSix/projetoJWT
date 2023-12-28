using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if(username == "caio" && password == "123456")
            {
                var token = TokenService.GenerateToken(new Domain.Models.Employee());
                return Ok(token);
            }

            return BadRequest("username or password invalid!");
        }
    }
}
