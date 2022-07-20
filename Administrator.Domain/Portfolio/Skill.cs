using Administrator.Domain.Common;

namespace Administrator.Domain.Portfolio
{
    public class Skill : BaseDomainModel
    {
        public Skill()
        {
            SkillsDetails = new HashSet<SkillDetail>();
        }

        public int UserInfoId { get; set; }
        public string Description { get; set; } = string.Empty;
        public virtual UserInfo? UserInfo { get; set; }
        public virtual ICollection<SkillDetail> SkillsDetails { get; set; }
    }
}
