using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class CategoriesController : ControllerBase
    {
        private readonly MvcProjectContext _categoryDb;
        private readonly IMapper _mapper;

        public CategoriesController(MvcProjectContext context, IMapper mapper)
        {
            _categoryDb = context;
            _mapper = mapper;

            if (!_categoryDb.Categories.Any())
            {
                _ = PostCategory(new CategoryCreationModel { Name = "Electronics" });
                _ = PostCategory(new CategoryCreationModel { Name = "Home" });
                _ = PostCategory(new CategoryCreationModel { Name = "Sports" });
                _ = PostCategory(new CategoryCreationModel { Name = "Clothes" });
                _ = PostCategory(new CategoryCreationModel { Name = "Education" });
                _ = PostCategory(new CategoryCreationModel { Name = "Transport" });
            }
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var list = await _categoryDb.Categories.ToListAsync();
            return Ok(list);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryReturnModel>> GetCategory(int id)
        {
            var entity = await _categoryDb.Categories.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return _mapper.Map<CategoryReturnModel>(entity);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(string id, Category entity)
        {
            if (id != entity.Id.ToString())
            {
                return BadRequest();
            }

            _categoryDb.Entry(entity).State = EntityState.Modified;

            try
            {
                await _categoryDb.SaveChangesAsync();
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
            _categoryDb.Categories.Add(categoryEntity);
            await _categoryDb.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = categoryEntity.Id }, categoryReturn);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(string id)
        {
            var entity = await _categoryDb.Categories.FirstOrDefaultAsync(p => p.Id.ToString() == id);
            if (entity == null)
            {
                return NotFound();
            }

            _categoryDb.Categories.Remove(entity);
            await _categoryDb.SaveChangesAsync();

            return Ok(entity);
        }

        private bool CategoryExists(string id)
        {
            return _categoryDb.Categories.Any(e => e.Id.ToString() == id);
        }
    }
}
