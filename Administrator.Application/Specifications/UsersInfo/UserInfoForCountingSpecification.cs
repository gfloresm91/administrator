using Administrator.Domain.Portfolio;

namespace Administrator.Application.Specifications.UsersInfo
{
    public class UserInfoForCountingSpecification : BaseSpecification<UserInfo>
    {
        public UserInfoForCountingSpecification(UserInfoSpecificationParams userInfoParams)
            :base(
                 x => string.IsNullOrEmpty(userInfoParams.Search) || x.UserName!.Contains(userInfoParams.Search)
                 )
        {
        }
    }
}
