using Administrator.Domain.Portfolio;
using System.Linq.Expressions;

namespace Administrator.Application.Specifications.UsersInfo
{
    public class UsersInfoWithSkillsSpecification : BaseSpecification<UserInfo>
    {
        public UsersInfoWithSkillsSpecification()
        {
            AddInclude(p => p.Skills!);
        }

        public UsersInfoWithSkillsSpecification(string username) : base(p => p.UserName!.Contains(username))
        {
            AddInclude(p => p.Skills!);
        }
    }
}
