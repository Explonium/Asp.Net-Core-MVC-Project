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
    public class OrderSuppliesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderSuppliesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderSupplies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderSupply>>> GetOrderSupply()
        {
            return await _context.OrderSupply.ToListAsync();
        }

        // GET: api/OrderSupplies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderSupply>> GetOrderSupply(Guid id)
        {
            var orderSupply = await _context.OrderSupply.FindAsync(id);

            if (orderSupply == null)
            {
                return NotFound();
            }

            return orderSupply;
        }

        // PUT: api/OrderSupplies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderSupply(Guid id, OrderSupply orderSupply)
        {
            if (id != orderSupply.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderSupply).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderSupplyExists(id))
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

        // POST: api/OrderSupplies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderSupply>> PostOrderSupply(OrderSupply orderSupply)
        {
            _context.OrderSupply.Add(orderSupply);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderSupply", new { id = orderSupply.Id }, orderSupply);
        }

        // DELETE: api/OrderSupplies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderSupply(Guid id)
        {
            var orderSupply = await _context.OrderSupply.FindAsync(id);
            if (orderSupply == null)
            {
                return NotFound();
            }

            _context.OrderSupply.Remove(orderSupply);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderSupplyExists(Guid id)
        {
            return _context.OrderSupply.Any(e => e.Id == id);
        }
    }
}
