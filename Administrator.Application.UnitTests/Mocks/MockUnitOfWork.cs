using Administrator.Infrastructure.Persistence;
using Administrator.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Administrator.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<PortfolioDbContext>()
                .UseInMemoryDatabase(databaseName: $"PortfolioDbContext-{dbContextId}")
                .Options;

            var portfolioDbContextFake = new PortfolioDbContext(options);
            portfolioDbContextFake.Database.EnsureDeleted();

            var mockUnitOfWork = new Mock<UnitOfWork>(portfolioDbContextFake);

            return mockUnitOfWork;
        }
    }
}
