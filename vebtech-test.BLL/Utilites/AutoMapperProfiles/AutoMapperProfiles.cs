using AutoMapper;
using vebtech_test.DAL.Entities;
using vebtech_test.DTO;

namespace vebtech_test.BLL.Utilites.AutoMapperProfiles
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                //Role
                CreateMap<Role, RoleDTO>().ReverseMap();
                CreateMap<Role, RoleToAddDTO>().ReverseMap();
                //User
                CreateMap<User, UserDTO>().ReverseMap();
                CreateMap<User, UserToAddDTO>().ReverseMap();
                CreateMap<User, UserToUpdateDTO>().ReverseMap();
                //
                CreateMap<User, UserRole>()
                   .ForMember(dest => dest.User, opt => opt.MapFrom(src => src))
                   .ForMember(dest => dest.Role, opt => opt.Ignore());
                CreateMap<Role, UserRole>()
                    .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src))
                    .ForMember(dest => dest.User, opt => opt.Ignore());

            }
        }
    }
}
