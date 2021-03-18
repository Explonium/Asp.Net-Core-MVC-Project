using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MVC_Project__online_shop_.Entities;
using MVC_Project__online_shop_.Models;

namespace MVC_Project__online_shop_.Controllers
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

        [Route("updatePersonalInformation")]
        [HttpPatch]
        [Authorize]
        public async Task<ActionResult<User>> PatchPersonalData([FromBody] JsonPatchDocument<UserProfilePatchModel> patchEntity)
        {
            var user = await db.GetUserAsync(sim.Context.User);
            if (user == null)
                return NotFound("This user doesn't exist");

            var patchedUser = _mapper.Map<UserProfilePatchModel>(user);
            patchEntity.ApplyTo(patchedUser);
            _mapper.Map(patchedUser, user);

            await db.UpdateAsync(user);

            return Ok(user);
        }
    }
}
