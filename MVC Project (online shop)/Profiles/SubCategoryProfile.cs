using AutoMapper;
using MVC_Project__online_shop_.Entities;
using MVC_Project__online_shop_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project__online_shop_.Profiles
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<SubCategoryCreationModel, SubCategory>();
            CreateMap<SubCategory, SubCategoryReturnModel>();
        }
    }
}
