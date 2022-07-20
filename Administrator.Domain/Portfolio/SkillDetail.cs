using Administrator.Domain.Common;

namespace Administrator.Domain.Portfolio
{
    public class SkillDetail : BaseDomainModel
    {
        public SkillDetail()
        {
            SkillsItems = new HashSet<SkillItem>();
        }

        public int SkillId { get; set; }
        public string Icon { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public virtual Skill? Skill { get; set; }
        public virtual ICollection<SkillItem> SkillsItems { get; set; }
    }
}
