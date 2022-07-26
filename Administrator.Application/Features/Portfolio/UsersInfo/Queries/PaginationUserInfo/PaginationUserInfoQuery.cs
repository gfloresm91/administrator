using Administrator.Application.Features.Portfolio.UsersInfo.Queries.Vms;
using Administrator.Application.Features.Shared.Queries;
using MediatR;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Queries.PaginationUserInfo
{
    public class PaginationUserInfoQuery : PaginationBaseQuery, IRequest<PaginationVm<UserInfoWithIncludesVm>>
    {
    }
}
