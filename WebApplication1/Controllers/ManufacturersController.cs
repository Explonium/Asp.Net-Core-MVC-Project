﻿using Microsoft.AspNetCore.Mvc;
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
    public class ManufacturersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ManufacturersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Manufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturer()
        {
            return await _context.Manufacturer.OrderBy(x => x.Name).ToListAsync();
        }

        // GET: api/Manufacturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturer>> GetManufacturer(Guid id)
        {
            var manufacturer = await _context.Manufacturer.FindAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return manufacturer;
        }

        // PUT: api/Manufacturers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacturer(Guid id, Manufacturer manufacturer)
        {
            if (id != manufacturer.Id)
            {
                return BadRequest();
            }

            _context.Entry(manufacturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacturerExists(id))
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

        // POST: api/Manufacturers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manufacturer>> PostManufacturer(Manufacturer manufacturer)
        {
            _context.Manufacturer.Add(manufacturer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManufacturer", new { id = manufacturer.Id }, manufacturer);
        }

        // DELETE: api/Manufacturers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer(Guid id)
        {
            var manufacturer = await _context.Manufacturer.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            _context.Manufacturer.Remove(manufacturer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManufacturerExists(Guid id)
        {
            return _context.Manufacturer.Any(e => e.Id == id);
        }
    }
}
