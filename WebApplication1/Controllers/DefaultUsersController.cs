using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcProjectApi.Entities;
using System.Threading.Tasks;

namespace MvcProjectApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultUsersController : ControllerBase
    {
        private readonly UserManager<User> db;

        public DefaultUsersController(UserManager<User> context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetCurrentUserData()
        {
            var user = await db.GetUserAsync(HttpContext.User);
            if (user == null)
                return BadRequest("This user doesn't exist");

            return Ok(user);
        }
    }
}
