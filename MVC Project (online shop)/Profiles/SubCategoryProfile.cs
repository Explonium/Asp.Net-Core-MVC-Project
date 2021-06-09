using AutoMapper;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Profiles
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
