using Administrator.Application.Features.Portfolio.UsersInfo.Commands.CreateUserInfo;
using Administrator.Domain.Portfolio;
using AutoMapper;

namespace Administrator.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserInfoCommand, UserInfo>();
        }
    }
}
