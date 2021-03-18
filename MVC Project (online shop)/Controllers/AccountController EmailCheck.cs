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
        [HttpGet]
        [Authorize]
        [Route("sendEmailConfirmationUrl")]
        public async Task<IActionResult> SendEmailConfirmationUrl()
        {
            var user = await db.GetUserAsync(sim.Context.User);
            if (user == null)
                return NotFound("This user doesn't exist");

            var code = await db.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Action(
                "ConfirmEmail",
                "Account",
                new { userId = user.Id, code = code },
                protocol: HttpContext.Request.Scheme);

            await _emailService.SendEmailAsync(user.Email, "Confirm your email", 
                $"<h3>Dear {user.UserName}!</h3>" +
                $"<p>Your email address was entered in registration form or has been changed in MVC Project profile page!<br>" +
                $"To confirm your email, you need to follow confirmation link.</p>" +
                $"<p>Confirmation link: <a href=\"https://localhost:51044/api.account/confirmEmail?userId={user.Id}&code={code}\n\">Confirm your email</a></p>" +
                $"<p>If you think you received this letter by mistake, then just ignore it.</p>" +
                $"<p>MVC Project, Ūbeļu iela 6, Riga, Latvia, LV-2127</p>"
                );

            return Ok();
        }

        [HttpGet]
        [Route("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest("User ID or email validation token is not valid");
            }
            var user = await db.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var result = await db.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return Ok("An email has been confirmed");
            else
                return BadRequest("Email validation token is not valid");
        }
    }
}
