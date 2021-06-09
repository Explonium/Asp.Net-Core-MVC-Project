using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcProjectApi.Entities;
using MvcProjectApi.Models;
using System.Threading.Tasks;

namespace MvcProjectApi.Controllers
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

            return Ok(_mapper.Map<UserReturnModel>(user));
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
        //[Authorize]
        public async Task<ActionResult<User>> PutPersonalInfo([FromBody] UserProfilePersonalInfo updateEntity)
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