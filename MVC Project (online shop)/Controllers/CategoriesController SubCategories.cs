using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public partial class CategoriesController
    {
        // GET: api/categories/subcategories
        [Route("subcategories")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategory>>> GetSubCategories()
        {
            var list = await _categoryDb.SubCategories.ToListAsync();
            return Ok(list);
        }

        // GET: api/categories/subcategories/5
        [Route("subcategories")]
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategory>> GetSubCategory(string id)
        {
            var entity = await _categoryDb.SubCategories.FirstOrDefaultAsync(e => e.Id.ToString() == id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        // GET: api/categories/subcategoriesbycategory/5
        [Route("subcategoriesbycategory")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SubCategory>>> GetSubCategoriesByCategory(string id)
        {
            var entity = await _categoryDb.Categories.FirstOrDefaultAsync(e => e.Id.ToString() == id);

            if (entity == null)
                return NotFound();

            var list = _categoryDb.SubCategories.ToList();
            return Ok(list);
        }

        // POST: api/categories/subcategories
        [Route("subcategories")]
        [HttpPost]
        public async Task<ActionResult<SubCategory>> AddSubCategory(SubCategoryCreationModel model)
        {
            var entity = _mapper.Map<SubCategory>(model);
            await _categoryDb.SubCategories.AddAsync(entity);
            await _categoryDb.SaveChangesAsync();

            return Ok(entity);
        }

        // PUT: api/categories/subcategories
        [Route("subcategories")]
        [HttpPut]
        public async Task<ActionResult<SubCategory>> EditSubCategory(SubCategoryCreationModel model)
        {
            var entity = _mapper.Map<SubCategory>(model);
            if (_categoryDb.SubCategories.Find(entity.Id) == null)
            {
                return NotFound();
            }

            _categoryDb.SubCategories.Update(entity);
            await _categoryDb.SaveChangesAsync();

            return Ok(entity);
        }

        // DELETE: api/categories/subcategories/5
        [Route("subcategories")]
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<SubCategory>>> DeleteSubCategory(string id)
        {
            var entity = _categoryDb.SubCategories.Find(new Guid(id));

            if (entity == null)
            {
                return NotFound();
            }

            _categoryDb.SubCategories.Remove(entity);
            await _categoryDb.SaveChangesAsync();

            return Ok(entity);
        }
    }
}
