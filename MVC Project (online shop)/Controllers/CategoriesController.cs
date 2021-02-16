using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project__online_shop_.Models;
using MVC_Project__online_shop_.Data;
using AutoMapper;
using MVC_Project__online_shop_.Entities;

namespace MVC_Project__online_shop_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryContext db;
        private readonly IMapper _mapper;

        public CategoriesController(CategoryContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;

            if (!db.Categories.Any())
            {
                db.Categories.Add(new Category { Name = "Clothes" });
                db.Categories.Add(new Category { Name = "Accessories" });
                db.SaveChanges();
            }
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryReturnModel>>> GetCategories()
        {
            var list = await db.Categories.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryReturnModel>>(list));
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryReturnModel>> GetCategory(int id)
        {
            var category = await db.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return _mapper.Map<CategoryReturnModel>(category);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(string id, Category category)
        {
            if (id != category.Id.ToString())
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CategoryReturnModel>> PostCategory(CategoryCreationModel category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            var categoryReturn = _mapper.Map<CategoryReturnModel>(categoryEntity);
            db.Categories.Add(categoryEntity);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = categoryEntity.Id }, categoryReturn);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryReturnModel>> DeleteCategory(int id)
        {
            var category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            await db.SaveChangesAsync();

            return _mapper.Map<CategoryReturnModel>(category);
        }

        private bool CategoryExists(string id)
        {
            return db.Categories.Any(e => e.Id.ToString() == id);
        }
    }
}
