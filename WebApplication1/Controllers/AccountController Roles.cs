using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcProjectApi.Entities;
using MvcProjectApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcProjectApi.Controllers
{
    public partial class AccountController
    {
        [HttpGet]
        [Authorize]
        [Route("roles")]
        public async Task<ActionResult<IEnumerable<string>>> GetRoles()
        {
            var user = await db.GetUserAsync(sim.Context.User);
            if (user == null)
                return NotFound("This user doesn't exist");

            var roles = await db.GetRolesAsync(user);

            return Ok(roles);
        }

        [HttpPost]
        //[Authorize]
        [Route("roles")]
        public async Task<ActionResult<IEnumerable<string>>> AddToRole(AddToRolesModel model)
        {
            var user = await db.FindByNameAsync(model.UserName);
            if (user == null)
                return NotFound($"User {model.UserName} not found!");

            foreach (var roleName in model.Roles)
            {
                bool x = await _roleManager.RoleExistsAsync(roleName);
                if (!x)
                {
                    // first we create Admin rool    
                    var role = new IdentityRole();
                    role.Name = roleName;
                    await _roleManager.CreateAsync(role);
                }

                await db.AddToRoleAsync(user, roleName);
            }
                //await db.AddToRoleAsync(user, role);
            //await db.AddToRolesAsync(user, model.Roles);

            return Ok($"Roles successfuly added to user {model.UserName}");
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        //[Authorize(Roles = "owner")]
        [HttpPut("{id}")]
        [Route("roles")]
        public async Task<ActionResult<string>> PutRoleAsync(string id, [FromBody] string role)
        {
            var user = await db.FindByNameAsync(id);
            if (user == null)
                return NotFound($"User {id} not found!");

            await db.AddToRoleAsync(user, role);

            return Ok($"Roles {role} successfuly added to user {id}");
        }
    }
}
