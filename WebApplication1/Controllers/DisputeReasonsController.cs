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
    public class DisputeReasonsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DisputeReasonsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DisputeReasons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisputeReason>>> GetDisputeReason()
        {
            return await _context.DisputeReason.OrderBy(x => x.Name).ToListAsync();
        }

        // GET: api/DisputeReasons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisputeReason>> GetDisputeReason(Guid id)
        {
            var disputeReason = await _context.DisputeReason.FindAsync(id);

            if (disputeReason == null)
            {
                return NotFound();
            }

            return disputeReason;
        }

        // PUT: api/DisputeReasons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisputeReason(Guid id, DisputeReason disputeReason)
        {
            if (id != disputeReason.Id)
            {
                return BadRequest();
            }

            _context.Entry(disputeReason).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisputeReasonExists(id))
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

        // POST: api/DisputeReasons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DisputeReason>> PostDisputeReason(DisputeReason disputeReason)
        {
            _context.DisputeReason.Add(disputeReason);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisputeReason", new { id = disputeReason.Id }, disputeReason);
        }

        // DELETE: api/DisputeReasons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisputeReason(Guid id)
        {
            var disputeReason = await _context.DisputeReason.FindAsync(id);
            if (disputeReason == null)
            {
                return NotFound();
            }

            _context.DisputeReason.Remove(disputeReason);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisputeReasonExists(Guid id)
        {
            return _context.DisputeReason.Any(e => e.Id == id);
        }
    }
}
