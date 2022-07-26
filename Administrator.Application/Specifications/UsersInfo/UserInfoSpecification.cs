using Administrator.Domain.Portfolio;

namespace Administrator.Application.Specifications.UsersInfo
{
    public class UserInfoSpecification : BaseSpecification<UserInfo>
    {
        public UserInfoSpecification(UserInfoSpecificationParams userInfoParams)
            :base(
                 x => string.IsNullOrEmpty(userInfoParams.Search) || x.UserName!.Contains(userInfoParams.Search)
                 )
        {
            ApplyPaging(userInfoParams.PageSize * (userInfoParams.PageIndex - 1), userInfoParams.PageSize); 

            if (!string.IsNullOrEmpty(userInfoParams.Sort))
            {
                switch (userInfoParams.Sort)
                {
                    case "userNameAsc":
                        AddOrderBy(p => p.UserName!);
                        break;

                    case "userNameDesc":
                        AddOrderByDescending(p => p.UserName!);
                        break;

                    case "userDescriptionAsc":
                        AddOrderBy(p => p.UserDescription!);
                        break;

                    case "userDescriptionDesc":
                        AddOrderByDescending(p => p.UserDescription!);
                        break;

                    case "createdDateAsc":
                        AddOrderBy(p => p.CreatedDate!);
                        break;

                    case "createdDateDesc":
                        AddOrderByDescending(p => p.CreatedDate!);
                        break;

                    default:
                        AddOrderBy(p => p.CreatedDate!);
                        break;
                }
            }
        }
    }
}
