using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcProjectApi.Data;
using MvcProjectApi.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliverersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeliverersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Deliverers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deliverer>>> GetDeliverer()
        {
            return await _context.Deliverer.ToListAsync();
        }

        // GET: api/Deliverers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deliverer>> GetDeliverer(string id)
        {
            var deliverer = await _context.Deliverer.FindAsync(id);

            if (deliverer == null)
            {
                return NotFound();
            }

            return deliverer;
        }

        // PUT: api/Deliverers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliverer(string id, Deliverer deliverer)
        {
            if (id != deliverer.Username)
            {
                return BadRequest();
            }

            _context.Entry(deliverer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DelivererExists(id))
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

        // POST: api/Deliverers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deliverer>> PostDeliverer(Deliverer deliverer)
        {
            _context.Deliverer.Add(deliverer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DelivererExists(deliverer.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeliverer", new { id = deliverer.Username }, deliverer);
        }

        // DELETE: api/Deliverers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliverer(string id)
        {
            var deliverer = await _context.Deliverer.FindAsync(id);
            if (deliverer == null)
            {
                return NotFound();
            }

            _context.Deliverer.Remove(deliverer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DelivererExists(string id)
        {
            return _context.Deliverer.Any(e => e.Username == id);
        }
    }
}
