using AutoMapper;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterModel, User>();
            CreateMap<User, UserReturnModel>();
            CreateMap<UserProfilePatchModel, User>();
            CreateMap<User, UserProfilePatchModel>();

            // Profile edit models
            CreateMap<UserProfileContactInfo, User>();
            CreateMap<UserProfilePersonalInfo, User>();
        }
    }
}
