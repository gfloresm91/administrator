using Administrator.Application.Contracts.Persistence;
using Administrator.Domain.Portfolio;
using AutoMapper;
using MediatR;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Queries.GetUserInfoList
{
    public class GetUserInfoListQueryHandler : IRequestHandler<GetUserInfoListQuery, List<UserInfo>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserInfoListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UserInfo>> Handle(GetUserInfoListQuery request, CancellationToken cancellationToken)
        {
            var userInfoList = await _unitOfWork.Repository<UserInfo>().GetAllAsync();

            return _mapper.Map<List<UserInfo>>(userInfoList);
        }
    }
}
