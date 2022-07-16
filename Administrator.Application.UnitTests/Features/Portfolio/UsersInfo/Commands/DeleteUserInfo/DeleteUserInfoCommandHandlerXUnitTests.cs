using Administrator.Application.Features.Portfolio.UsersInfo.Commands.DeleteUserInfo;
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

namespace Administrator.Application.UnitTests.Features.Portfolio.UsersInfo.Commands.DeleteUserInfo
{
    public class DeleteUserInfoCommandHandlerXUnitTests
    {
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<DeleteUserInfoCommandHandler>> _logger;

        public DeleteUserInfoCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _logger = new Mock<ILogger<DeleteUserInfoCommandHandler>>();

            MockUserInfoRepository.AddDataUserInfoRepository(_unitOfWork.Object.PortfolioDbContext);
        }

        [Fact]
        public async Task DeleteUserInfoCommand_InputUserInfoById_ReturnsUnit()
        {
            var userInfoInput = new DeleteUserInfoCommand
            {
                Id = 8001
            };

            var handler = new DeleteUserInfoCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);

            var result = await handler.Handle(userInfoInput, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }
}
