using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project__online_shop_.Data;
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

    }
}
