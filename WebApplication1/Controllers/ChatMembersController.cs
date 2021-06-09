using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcProjectApi.Data;
using MvcProjectApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMembersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChatMembersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ChatMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatMember>>> GetChatMember()
        {
            return await _context.ChatMember.ToListAsync();
        }

        // GET: api/ChatMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatMember>> GetChatMember(Guid id)
        {
            var chatMember = await _context.ChatMember.FindAsync(id);

            if (chatMember == null)
            {
                return NotFound();
            }

            return chatMember;
        }

        // PUT: api/ChatMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatMember(Guid id, ChatMember chatMember)
        {
            if (id != chatMember.Id)
            {
                return BadRequest();
            }

            _context.Entry(chatMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatMemberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ChatMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChatMember>> PostChatMember(ChatMember chatMember)
        {
            _context.ChatMember.Add(chatMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatMember", new { id = chatMember.Id }, chatMember);
        }

        // DELETE: api/ChatMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatMember(Guid id)
        {
            var chatMember = await _context.ChatMember.FindAsync(id);
            if (chatMember == null)
            {
                return NotFound();
            }

            _context.ChatMember.Remove(chatMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatMemberExists(Guid id)
        {
            return _context.ChatMember.Any(e => e.Id == id);
        }
    }
}
