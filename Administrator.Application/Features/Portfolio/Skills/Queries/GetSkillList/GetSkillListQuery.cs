using Administrator.Domain.Portfolio;
using MediatR;

namespace Administrator.Application.Features.Portfolio.Skills.Queries.GetSkillList
{
    public class GetSkillListQuery : IRequest<List<SkillVm>>
    {
        public virtual UserInfo? UserInfo { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
