using Administrator.Domain.Portfolio;

namespace Administrator.Application.Features.Portfolio.Skills.Queries.GetSkillList
{
    public class SkillVm
    {
        public virtual UserInfo? UserInfo { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
