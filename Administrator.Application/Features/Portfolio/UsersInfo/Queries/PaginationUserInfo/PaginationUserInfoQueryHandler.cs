using Administrator.Application.Contracts.Persistence;
using Administrator.Application.Features.Portfolio.UsersInfo.Queries.Vms;
using Administrator.Application.Features.Shared.Queries;
using Administrator.Application.Specifications.UsersInfo;
using Administrator.Domain.Portfolio;
using AutoMapper;
using MediatR;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Queries.PaginationUserInfo
{
    public class PaginationUserInfoQueryHandler : IRequestHandler<PaginationUserInfoQuery, PaginationVm<UserInfoWithIncludesVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaginationUserInfoQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginationVm<UserInfoWithIncludesVm>> Handle(PaginationUserInfoQuery request, CancellationToken cancellationToken)
        {
            var userInfoSpecificationParams = new UserInfoSpecificationParams
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Search = request.Search,
                Sort = request.Sort,
            };

            var spec = new UserInfoSpecification(userInfoSpecificationParams);
            var usersInfo = await _unitOfWork.Repository<UserInfo>().GetAllWithSpec(spec);

            var specCount = new UserInfoForCountingSpecification(userInfoSpecificationParams);
            var totalUsersInfo = await _unitOfWork.Repository<UserInfo>().CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalUsersInfo) / Convert.ToDecimal(request.PageSize));
            var totalPages = Convert.ToInt32(rounded);

            var data = _mapper.Map<IReadOnlyList<UserInfo>, IReadOnlyList<UserInfoWithIncludesVm>>(usersInfo);

            var pagination = new PaginationVm<UserInfoWithIncludesVm>
            {
                Count = totalUsersInfo,
                Data = data,
                PageCount = totalPages,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };

            return pagination;
        }
    }
}
