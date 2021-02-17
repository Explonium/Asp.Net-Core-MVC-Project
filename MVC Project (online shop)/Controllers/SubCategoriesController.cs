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
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly SubCategoryContext db;
        private readonly IMapper _mapper;

        public SubCategoriesController(SubCategoryContext subCategoryContext, IMapper mapper)
        {
            db = subCategoryContext;
            _mapper = mapper;
        }

        // GET: api/SubCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoryReturnModel>>> GetSubCategories()
        {
            var list = await db.SubCategories.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<SubCategoryReturnModel>>(list));
        }

        // GET: api/SubCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SubCategoryReturnModel>>> GetSubCategory(string id)
        {
            var entity = await db.SubCategories.FirstOrDefaultAsync(e => e.Id.ToString() == id);

            if (entity == null)
                return NotFound();

            return Ok(_mapper.Map<SubCategoryReturnModel>(entity));
        }

        // POST: api/SubCategories
        [HttpPost]
        public async Task<ActionResult<IEnumerable<SubCategoryReturnModel>>> AddSubCategory(SubCategoryCreationModel model)
        {
            var entity = _mapper.Map<SubCategory>(model);
            await db.SubCategories.AddAsync(entity);
            await db.SaveChangesAsync();

            return Ok(_mapper.Map<IEnumerable<SubCategoryReturnModel>>(entity));
        }

        // PUT: api/SubCategories
        [HttpPut]
        public async Task<ActionResult<IEnumerable<SubCategoryReturnModel>>> EditSubCategory(SubCategoryCreationModel model)
        {
            var entity = _mapper.Map<SubCategory>(model);
            if (db.SubCategories.Find(entity.Id) == null)
            {
                return NotFound();
            }

            db.SubCategories.Update(entity);
            await db.SaveChangesAsync();

            return Ok(_mapper.Map<SubCategoryReturnModel>(entity));
        }

        // PUT: api/SubCategories/5
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<SubCategoryReturnModel>>> DeleteSubCategory(string id)
        {
            var entity = db.SubCategories.Find(new Guid(id));

            if (entity == null)
            {
                return NotFound();
            }

            db.SubCategories.Remove(entity);
            await db.SaveChangesAsync();

            return Ok(entity);
        }
    }
}
