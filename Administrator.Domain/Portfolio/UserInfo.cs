using Administrator.Domain.Common;

namespace Administrator.Domain.Portfolio
{
    public class UserInfo : BaseDomainModel
    {
        public string? ProfileImage { get; set; }
        public string? UserName { get; set; }
        public string? UserDescription { get; set; }
    }
}
