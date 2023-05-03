using AutoMapper;
using CommonService.BusinessLogicLayer.DTO;
using CommonService.DataAccessLayer.Entities;

namespace CommonService.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<NewUserRequestModel, User>()
                .ForMember(m => m.CreatedOn, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(m => m.Password, opt => opt.MapFrom(src => EasyEncryption.MD5.ComputeMD5Hash(src.Password)));

            CreateMap<UserRequestModel, User>();

            CreateMap<User, UserResponseModel>();

            CreateMap<Role, RoleResponseModel>();
        }
    }
}
