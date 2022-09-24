using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using netCoreApiJWT.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace netCoreApiJWT.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "administrator,Seller")]
    public class UserController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("public")]
        public IActionResult open()
        {
            return Ok("good public");
        }
        [HttpGet("Admins")]
        public async Task<ActionResult<User>> AdminOnly()
        {
            var user = await Task.FromResult(GetUser());
            return Ok($"hello {user.UserName}");
        }

        private User GetUser()
        {
            var claims = (HttpContext.User.Identity as ClaimsIdentity).Claims;
            if (claims.Any() != false)
            {
                return new User
                {
                    UserName = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value,
                    EmailAdress = claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value,
                    Name = claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName).Value,
                    Surname = claims.FirstOrDefault(x => x.Type == ClaimTypes.Surname).Value,
                    Role = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value,
                };
            }
            return new User();
        }
    }
}