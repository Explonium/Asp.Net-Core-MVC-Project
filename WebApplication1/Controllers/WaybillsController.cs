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
    public class WaybillsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WaybillsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Waybills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Waybill>>> GetWaybill()
        {
            return await _context.Waybill.ToListAsync();
        }

        // GET: api/Waybills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Waybill>> GetWaybill(Guid id)
        {
            var waybill = await _context.Waybill.FindAsync(id);

            if (waybill == null)
            {
                return NotFound();
            }

            return waybill;
        }

        // PUT: api/Waybills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaybill(Guid id, Waybill waybill)
        {
            if (id != waybill.Id)
            {
                return BadRequest();
            }

            _context.Entry(waybill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaybillExists(id))
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

        // POST: api/Waybills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Waybill>> PostWaybill(Waybill waybill)
        {
            _context.Waybill.Add(waybill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaybill", new { id = waybill.Id }, waybill);
        }

        // DELETE: api/Waybills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWaybill(Guid id)
        {
            var waybill = await _context.Waybill.FindAsync(id);
            if (waybill == null)
            {
                return NotFound();
            }

            _context.Waybill.Remove(waybill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WaybillExists(Guid id)
        {
            return _context.Waybill.Any(e => e.Id == id);
        }
    }
}
