using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public partial class AccountController
    {
        [Authorize(Roles = "owner")]
        [HttpPost("{id}")]
        [Route("signin")]
        public async Task<IActionResult> AddToRoleAsync(string id, string role)
        {
            var user = await db.FindByIdAsync(id);
            if (user == null)
                return NotFound($"User {id} not found!");

            await db.AddToRoleAsync(user, role);

            return Ok($"Role {role} successfuly added to user {id}");
        }
    }
}
