using Administrator.Domain.Portfolio;
using MediatR;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Queries.GetUserInfoList
{
    public class GetUserInfoListQuery : IRequest<List<UserInfo>>
    {
        public string ProfileImage { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserDescription { get; set; } = string.Empty;
    }
}
