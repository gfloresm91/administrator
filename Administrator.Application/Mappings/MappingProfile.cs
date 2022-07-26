using Administrator.Application.Features.Portfolio.Skills.Commands.CreateSkill;
using Administrator.Application.Features.Portfolio.Skills.Queries.GetSkillList;
using Administrator.Application.Features.Portfolio.UsersInfo.Commands.CreateUserInfo;
using Administrator.Application.Features.Portfolio.UsersInfo.Commands.UpdateUserInfo;
using Administrator.Application.Features.Portfolio.UsersInfo.Queries.Vms;
using Administrator.Domain.Portfolio;
using AutoMapper;

namespace Administrator.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserInfoCommand, UserInfo>();
            CreateMap<UpdateUserInfoCommand, UserInfo>();
            CreateMap<UserInfo, UserInfoVm>();
            CreateMap<UserInfo, UserInfoWithIncludesVm>();

            CreateMap<Skill, SkillVm>();
            CreateMap<CreateSkillCommand, Skill>();
        }
    }
}
