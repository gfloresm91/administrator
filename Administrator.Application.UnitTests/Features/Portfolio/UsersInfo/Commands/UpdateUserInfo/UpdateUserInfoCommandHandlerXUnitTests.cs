using Administrator.Application.Contracts.Infrastructure;
using Administrator.Application.Features.Portfolio.UsersInfo.Commands.UpdateUserInfo;
using Administrator.Application.Mappings;
using Administrator.Application.UnitTests.Mocks;
using Administrator.Application.UnitTests.Mocks.Portfolio;
using Administrator.Infrastructure.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace Administrator.Application.UnitTests.Features.Portfolio.UsersInfo.Commands.UpdateUserInfo
{
    public class UpdateUserInfoCommandHandlerXUnitTests
    {
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Mock<IEmailService> _emailService;
        private readonly Mock<ILogger<UpdateUserInfoCommandHandler>> _logger;

        public UpdateUserInfoCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _emailService = new Mock<IEmailService>();

            _logger = new Mock<ILogger<UpdateUserInfoCommandHandler>>();

            MockUserInfoRepository.AddDataUserInfoRepository(_unitOfWork.Object.PortfolioDbContext);
        }

        [Fact]
        public async Task UpdateUserInfoCommand_InputUserInfo_ReturnsUnit()
        {
            var userInfoInput = new UpdateUserInfoCommand
            {
                Id = 8001,
                UserName = "gabrielflores",
                ProfileImage = "Test edit",
                UserDescription = "Test edit"
            };

            var handler = new UpdateUserInfoCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(userInfoInput, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }
}
