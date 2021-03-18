using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project__online_shop_.Data;
using MVC_Project__online_shop_.Entities;
using MVC_Project__online_shop_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project__online_shop_.Controllers
{
    public partial class CategoriesController
    {
        // GET: api/categories/subcategories
        [Route("subcategories")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoryReturnModel>>> GetSubCategories()
        {
            var list = await _categoryDb.SubCategories.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<SubCategoryReturnModel>>(list));
        }

        // GET: api/categories/subcategories/5
        [Route("subcategories")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SubCategoryReturnModel>>> GetSubCategory(string id)
        {
            var entity = await _categoryDb.SubCategories.FirstOrDefaultAsync(e => e.Id.ToString() == id);

            if (entity == null)
                return NotFound();

            return Ok(_mapper.Map<SubCategoryReturnModel>(entity));
        }

        // GET: api/categories/subcategories/5
        [Route("subcategoriesbycategory")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SubCategoryReturnModel>>> GetSubCategoriesByCategory(string id)
        {
            var entity = await _categoryDb.Categories.FirstOrDefaultAsync(e => e.Id.ToString() == id);

            if (entity == null)
                return NotFound();

            var list = _categoryDb.SubCategories.ToList();

            return Ok(_mapper.Map<List<SubCategoryReturnModel>>(list));
        }

        // POST: api/categories/subcategories
        [Route("subcategories")]
        [HttpPost]
        public async Task<ActionResult<SubCategoryReturnModel>> AddSubCategory(SubCategoryCreationModel model)
        {
            var entity = _mapper.Map<SubCategory>(model);
            await _categoryDb.SubCategories.AddAsync(entity);
            await _categoryDb.SaveChangesAsync();

            return Ok(_mapper.Map<SubCategoryReturnModel>(entity));
        }

        // PUT: api/categories/subcategories
        [Route("subcategories")]
        [HttpPut]
        public async Task<ActionResult<IEnumerable<SubCategoryReturnModel>>> EditSubCategory(SubCategoryCreationModel model)
        {
            var entity = _mapper.Map<SubCategory>(model);
            if (_categoryDb.SubCategories.Find(entity.Id) == null)
            {
                return NotFound();
            }

            _categoryDb.SubCategories.Update(entity);
            await _categoryDb.SaveChangesAsync();

            return Ok(_mapper.Map<SubCategoryReturnModel>(entity));
        }

        // PUT: api/categories/subcategories/5
        [Route("subcategories")]
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<SubCategoryReturnModel>>> DeleteSubCategory(string id)
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
