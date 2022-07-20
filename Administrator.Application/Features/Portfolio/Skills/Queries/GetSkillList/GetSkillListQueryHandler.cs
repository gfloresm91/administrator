using Administrator.Application.Contracts.Persistence;
using Administrator.Domain.Portfolio;
using AutoMapper;
using MediatR;

namespace Administrator.Application.Features.Portfolio.Skills.Queries.GetSkillList
{
    public class GetSkillListQueryHandler : IRequestHandler<GetSkillListQuery, List<Skill>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSkillListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Skill>> Handle(GetSkillListQuery request, CancellationToken cancellationToken)
        {
            var skillList = await _unitOfWork.Repository<Skill>().GetAsync(null, null, "UserInfo");

            return _mapper.Map<List<Skill>>(skillList);
        }
    }
}
