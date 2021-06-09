using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Models;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public partial class AccountController
    {
        [Route("getMyInformation")]
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserReturnModel>> GetCurrentUserData()
        {
            var user = await db.GetUserAsync(sim.Context.User);
            if (user == null)
                return NotFound("This user doesn't exist");

            return Ok(user);
        }

        [Route("updatePersonalInformation")]
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<User>> PutPersonalData([FromBody] UserProfilePatchModel updateEntity)
        {
            var user = await db.GetUserAsync(sim.Context.User);
            if (user == null)
                return NotFound("This user doesn't exist");

            _mapper.Map(updateEntity, user);

            await db.UpdateAsync(user);

            return Ok(user);
        }

        [Route("updatePersonalInfo")]
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<User>> PutContactInfo([FromBody] UserProfilePersonalInfo updateEntity)
        {
            var user = await db.GetUserAsync(sim.Context.User);
            if (user == null)
                return NotFound("This user doesn't exist");

            user = _mapper.Map(updateEntity, user);

            await db.UpdateAsync(user);

            return Ok(user);
        }
    }
}