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
    public partial class CategoriesController : ControllerBase
    {
        private readonly CategoryContext _categoryDb;
        private readonly IMapper _mapper;

        public CategoriesController(CategoryContext context, IMapper mapper)
        {
            _categoryDb = context;
            _mapper = mapper;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryReturnModel>>> GetCategories()
        {
            var list = await _categoryDb.Categories.ToListAsync();
            return Ok(_mapper.Map<List<CategoryReturnModel>>(list));
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
        public async Task<ActionResult<CategoryReturnModel>> DeleteCategory(int id)
        {
            var entity = await _categoryDb.Categories.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _categoryDb.Categories.Remove(entity);
            await _categoryDb.SaveChangesAsync();

            return _mapper.Map<CategoryReturnModel>(entity);
        }

        private bool CategoryExists(string id)
        {
            return _categoryDb.Categories.Any(e => e.Id.ToString() == id);
        }
    }
}
