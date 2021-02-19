using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project__online_shop_.Entities;
using MVC_Project__online_shop_.Models;

namespace MVC_Project__online_shop_.Controllers
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
