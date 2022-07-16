using Administrator.Domain.Portfolio;
using Administrator.Infrastructure.Persistence;
using AutoFixture;

namespace Administrator.Application.UnitTests.Mocks.Portfolio
{
    public static class MockUserInfoRepository
    {
        public static void AddDataUserInfoRepository(PortfolioDbContext portfolioDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var usersInfo = fixture.CreateMany<UserInfo>().ToList();

            usersInfo.Add(fixture.Build<UserInfo>()
                .With(tr => tr.Id, 8001)
                .Create());

            portfolioDbContextFake.UsersInfo!.AddRange(usersInfo);
            portfolioDbContextFake.SaveChanges();
        }
    }
}
