using Administrator.Application.Contracts.Persistence;
using Administrator.Application.Features.Portfolio.UsersInfo.Queries.Vms;
using Administrator.Domain.Portfolio;
using AutoMapper;
using MediatR;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Queries.GetUserInfoList
{
    public class GetUserInfoListQueryHandler : IRequestHandler<GetUserInfoListQuery, List<UserInfoVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserInfoListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UserInfoVm>> Handle(GetUserInfoListQuery request, CancellationToken cancellationToken)
        {
            var userInfoList = await _unitOfWork.Repository<UserInfo>().GetAsync(null, null, "Skills");

            return _mapper.Map<List<UserInfoVm>>(userInfoList);
        }
    }
}
