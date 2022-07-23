using Administrator.Application.Features.Portfolio.Skills.Queries.GetSkillList;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Queries.Vms
{
    public class UserInfoVm
    {
        public string ProfileImage { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserDescription { get; set; } = string.Empty;
        public virtual ICollection<SkillVm>? Skills { get; set; }
    }
}
