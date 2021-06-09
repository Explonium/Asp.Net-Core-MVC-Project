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
    public class CartedProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CartedProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CartedProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartedProduct>>> GetCartedProduct()
        {
            return await _context.CartedProduct.ToListAsync();
        }

        // GET: api/CartedProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartedProduct>> GetCartedProduct(Guid id)
        {
            var cartedProduct = await _context.CartedProduct.FindAsync(id);

            if (cartedProduct == null)
            {
                return NotFound();
            }

            return cartedProduct;
        }

        // PUT: api/CartedProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartedProduct(Guid id, CartedProduct cartedProduct)
        {
            if (id != cartedProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(cartedProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartedProductExists(id))
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

        // POST: api/CartedProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CartedProduct>> PostCartedProduct(CartedProduct cartedProduct)
        {
            _context.CartedProduct.Add(cartedProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartedProduct", new { id = cartedProduct.Id }, cartedProduct);
        }

        // DELETE: api/CartedProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartedProduct(Guid id)
        {
            var cartedProduct = await _context.CartedProduct.FindAsync(id);
            if (cartedProduct == null)
            {
                return NotFound();
            }

            _context.CartedProduct.Remove(cartedProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartedProductExists(Guid id)
        {
            return _context.CartedProduct.Any(e => e.Id == id);
        }
    }
}
