using AutoMapper;
using AdminService.BusinessLogicLayer.DTO;
using AdminService.DataAccessLayer.Entities;

namespace AdminService.Core
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

            CreateMap<MachineRequestModel, Machine>();

            CreateMap<Machine, MachineResponseModel>();
        }
    }
}
