using Administrator.Application.Contracts.Persistence.Portfolio;
using Administrator.Domain.Portfolio;
using Administrator.Infrastructure.Persistence;

namespace Administrator.Infrastructure.Repositories
{
    public class UserInfoRepository : RepositoryBase<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(PortfolioDbContext context) : base(context)
        {
        }
    }
}
