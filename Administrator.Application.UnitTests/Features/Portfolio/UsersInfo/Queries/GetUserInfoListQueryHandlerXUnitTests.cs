using Administrator.Application.Features.Portfolio.UsersInfo.Queries.GetUserInfoList;
using Administrator.Application.Mappings;
using Administrator.Application.UnitTests.Mocks;
using Administrator.Application.UnitTests.Mocks.Portfolio;
using Administrator.Domain.Portfolio;
using Administrator.Infrastructure.Repositories;
using AutoMapper;
using Moq;
using Shouldly;
using Xunit;

namespace Administrator.Application.UnitTests.Features.Portfolio.UsersInfo.Queries
{
    public class GetUserInfoListQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetUserInfoListQueryHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            MockUserInfoRepository.AddDataUserInfoRepository(_unitOfWork.Object.PortfolioDbContext);
        }

        [Fact]
        public async Task GetVideoListTest()
        {
            var handler = new GetUserInfoListQueryHandler(_unitOfWork.Object, _mapper);
            var request = new GetUserInfoListQuery();

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<UserInfo>>();
        }
    }
}
