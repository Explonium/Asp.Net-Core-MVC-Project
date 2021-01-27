using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project__online_shop_.Models;

namespace MVC_Project__online_shop_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext db;

        public UsersController(UserContext context)
        {
            db = context;

            if (!db.Users.Any())
            {
                db.Users.Add(new User { Username = "AleksejsZubovs" });
                db.Users.Add(new User { Username = "Abrakadabra" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await db.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserById(int id)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(ViewModels.RegisterUserModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            // Salt
            string newUserSalt = Guid.NewGuid().ToString();
            // Password
            var data = Encoding.ASCII.GetBytes(user.Password + newUserSalt);
            var sha1data = new SHA1CryptoServiceProvider().ComputeHash(data);
            string encryptedPassword = new ASCIIEncoding().GetString(sha1data);
            // User
            User newUser = new User { Username = user.Login, Salt = newUserSalt, EncryptedPassword = encryptedPassword };

            db.Users.Add(newUser);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<User>> PutUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (!db.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();

            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
