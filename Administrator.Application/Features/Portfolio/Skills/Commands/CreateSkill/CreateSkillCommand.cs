using MediatR;

namespace Administrator.Application.Features.Portfolio.Skills.Commands.CreateSkill
{
    public class CreateSkillCommand : IRequest<int>
    {
        public int UserInfoId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
