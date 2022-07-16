using Administrator.Application.Contracts.Infrastructure;
using Administrator.Application.Features.Portfolio.UsersInfo.Commands.CreateUserInfo;
using Administrator.Application.Mappings;
using Administrator.Application.UnitTests.Mocks;
using Administrator.Application.UnitTests.Mocks.Portfolio;
using Administrator.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace Administrator.Application.UnitTests.Features.Portfolio.UsersInfo.Commands.CreateUserInfo
{
    public class CreateUserInfoCommandHandlerXUnitTests
    {
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Mock<IEmailService> _emailService;
        private readonly Mock<ILogger<CreateUserInfoCommandHandler>> _logger;

        public CreateUserInfoCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _emailService = new Mock<IEmailService>();

            _logger = new Mock<ILogger<CreateUserInfoCommandHandler>>();

            MockUserInfoRepository.AddDataUserInfoRepository(_unitOfWork.Object.PortfolioDbContext);
        }

        [Fact]
        public async Task CreateUserInfoCommand_InputUserInfo_ReturnsNumber()
        {
            var userInfoInput = new CreateUserInfoCommand
            {
                UserName = "Test",
                ProfileImage = "Test",
                UserDescription = "Test",
            };

            var handler = new CreateUserInfoCommandHandler(_unitOfWork.Object, _mapper, _emailService.Object, _logger.Object);
            var result = await handler.Handle(userInfoInput, CancellationToken.None);

            result.ShouldBeOfType<int>();
        }
    }
}
