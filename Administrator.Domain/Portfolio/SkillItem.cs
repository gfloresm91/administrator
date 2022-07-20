using Administrator.Domain.Common;

namespace Administrator.Domain.Portfolio
{
    public class SkillItem : BaseDomainModel
    {
        public int SkillDetailId { get; set; }
        public string Item { get; set; } = string.Empty;
        public virtual SkillDetail? SkillDetail { get; set; }
    }
}
