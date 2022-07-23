using Administrator.Application.Features.Portfolio.UsersInfo.Queries.Vms;
using MediatR;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Queries.GetUserInfoListByUsername
{
    public class GetUserInfoListByUsernameQuery : IRequest<List<UserInfoVm>>
    {
        public string? Username { get; set; }

        public GetUserInfoListByUsernameQuery(string? username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
