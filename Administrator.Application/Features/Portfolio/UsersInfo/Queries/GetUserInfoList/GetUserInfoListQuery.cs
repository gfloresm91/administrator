using Administrator.Application.Features.Portfolio.UsersInfo.Queries.Vms;
using MediatR;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Queries.GetUserInfoList
{
    public class GetUserInfoListQuery : IRequest<List<UserInfoVm>>
    {
    }
}
