using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcProjectApi.Data;
using MvcProjectApi.Entities;
using MvcProjectApi.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> db;
        private readonly SignInManager<User> sim;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public VendorsController(AppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IEmailService emailService, IMapper mapper)
        {
            _context = context;
            db = userManager;
            sim = signInManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _mapper = mapper;
        }

        // GET: api/Vendors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetVendor()
        {
            return await _context.Vendor.ToListAsync();
        }

        // GET: api/Vendors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(string id)
        {
            var vendor = await _context.Vendor.FindAsync(id);

            if (vendor == null)
            {
                return NotFound();
            }

            return vendor;
        }

        // PUT: api/Vendors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor(string id, Vendor vendor)
        {
            if (id != vendor.Username)
            {
                return BadRequest();
            }

            _context.Entry(vendor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(id))
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

        // POST: api/Vendors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vendor>> PostVendor(Vendor vendor)
        {
            var user = await db.FindByIdAsync(vendor.Username);
            if (user == null)
                return NotFound("This user doesn't exist");

            _context.Vendor.Add(vendor);
            try
            {
                await _context.SaveChangesAsync();

                bool x = await _roleManager.RoleExistsAsync("vendor");
                if (!x)
                { 
                    var role = new IdentityRole();
                    role.Name = "vendor";
                    await _roleManager.CreateAsync(role);
                }

                await db.AddToRoleAsync(user, "vendor");
            }
            catch (DbUpdateException e)
            {
                if (VendorExists(vendor.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVendor", new { id = vendor.Username }, vendor);
        }

        [HttpPost]
        [Route("Become")]
        public async Task<ActionResult<Vendor>> BecomeVendor()
        {
            var user = await db.GetUserAsync(sim.Context.User);
            if (user == null)
                return NotFound("This user doesn't exist");

            var vendor = new Vendor { Username = user.Id, CompanyName = "" };

            return await PostVendor(vendor);
        }

        // DELETE: api/Vendors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(string id)
        {
            var vendor = await _context.Vendor.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }

            _context.Vendor.Remove(vendor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendorExists(string id)
        {
            return _context.Vendor.Any(e => e.Username == id);
        }
    }
}
