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
    public class DeliveryRoutesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeliveryRoutesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryRoutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryRoute>>> GetDeliveryRoute()
        {
            return await _context.DeliveryRoute.ToListAsync();
        }

        // GET: api/DeliveryRoutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryRoute>> GetDeliveryRoute(Guid id)
        {
            var deliveryRoute = await _context.DeliveryRoute.FindAsync(id);

            if (deliveryRoute == null)
            {
                return NotFound();
            }

            return deliveryRoute;
        }

        // PUT: api/DeliveryRoutes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryRoute(Guid id, DeliveryRoute deliveryRoute)
        {
            if (id != deliveryRoute.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveryRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryRouteExists(id))
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

        // POST: api/DeliveryRoutes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeliveryRoute>> PostDeliveryRoute(DeliveryRoute deliveryRoute)
        {
            _context.DeliveryRoute.Add(deliveryRoute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveryRoute", new { id = deliveryRoute.Id }, deliveryRoute);
        }

        // DELETE: api/DeliveryRoutes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryRoute(Guid id)
        {
            var deliveryRoute = await _context.DeliveryRoute.FindAsync(id);
            if (deliveryRoute == null)
            {
                return NotFound();
            }

            _context.DeliveryRoute.Remove(deliveryRoute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryRouteExists(Guid id)
        {
            return _context.DeliveryRoute.Any(e => e.Id == id);
        }
    }
}
