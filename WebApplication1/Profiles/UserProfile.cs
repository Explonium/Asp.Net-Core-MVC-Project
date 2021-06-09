using AutoMapper;
using MvcProjectApi.Entities;
using MvcProjectApi.Models;

namespace MvcProjectApi.Profiles
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
