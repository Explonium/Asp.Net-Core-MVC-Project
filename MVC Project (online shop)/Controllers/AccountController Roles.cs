using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MVC_Project__online_shop_.Entities;
using MVC_Project__online_shop_.Models;
using MVC_Project__online_shop_.Services;

namespace MVC_Project__online_shop_.Controllers
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
