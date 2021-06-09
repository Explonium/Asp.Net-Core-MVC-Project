using AutoMapper;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Profiles
{
    public class CategoryProfie : Profile
    {
        public CategoryProfie()
        {
            CreateMap<Category, CategoryReturnModel>();
            CreateMap<CategoryCreationModel, Category>();
        }
    }
}
