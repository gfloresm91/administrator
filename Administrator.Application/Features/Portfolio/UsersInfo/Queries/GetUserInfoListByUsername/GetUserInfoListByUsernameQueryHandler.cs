using Administrator.Application.Contracts.Persistence;
using Administrator.Application.Features.Portfolio.UsersInfo.Queries.Vms;
using Administrator.Application.Specifications.UsersInfo;
using Administrator.Domain.Portfolio;
using AutoMapper;
using MediatR;
using System.Linq.Expressions;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Queries.GetUserInfoListByUsername
{
    public class GetUserInfoListByUsernameQueryHandler : IRequestHandler<GetUserInfoListByUsernameQuery, List<UserInfoVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserInfoListByUsernameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UserInfoVm>> Handle(GetUserInfoListByUsernameQuery request, CancellationToken cancellationToken)
        {
            //var includes = new List<Expression<Func<UserInfo, object>>>();
            //includes.Add(p => p.Skills!);

            //var userInfoList = await _unitOfWork.Repository<UserInfo>().GetAsync(
            //    userInfo => userInfo.CreatedBy == request.Username,
            //    userInfo => userInfo.OrderBy(x => x.CreatedDate),
            //    includes,
            //    true
            //    );

            var spec = new UsersInfoWithSkillsSpecification(request.Username!);
            var userInfoList = await _unitOfWork.Repository<UserInfo>().GetAllWithSpec(spec);

            return _mapper.Map<List<UserInfoVm>>(userInfoList);
        }
    }
}
