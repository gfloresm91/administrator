using Administrator.Domain.Common;

namespace Administrator.Domain.Portfolio
{
    public class UserInfo : BaseDomainModel
    {
        public UserInfo()
        {
            Skills = new HashSet<Skill>();
        }

        public string? ProfileImage { get; set; }
        public string? UserName { get; set; }
        public string? UserDescription { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
