using Administrator.Domain.Portfolio;
using Microsoft.Extensions.Logging;

namespace Administrator.Infrastructure.Persistence
{
    public class PortfolioDbContextSeed
    {
        public static async Task SeedAsync(PortfolioDbContext context, ILoggerFactory loggerFactory)
        {
            if (!context.UsersInfo!.Any())
            {
                var logger = loggerFactory.CreateLogger<PortfolioDbContextSeed>();
                //context.UsersInfo!.AddRange(GetPreconfiguredUserInfo());
                //await context.SaveChangesAsync();
                logger.LogInformation("Insert new records to db {context}", typeof(PortfolioDbContext).Name);
            }
        }

        private static IEnumerable<UserInfo> GetPreconfiguredUserInfo()
        {
            return new List<UserInfo>
            {
                new UserInfo
                {
                    CreatedBy = "gflores",
                    UserName = "Test username 1",
                    UserDescription = "Test user description 1",
                    ProfileImage = "Test profile image 1"
                },
                new UserInfo
                {
                    CreatedBy = "gflores",
                    UserName = "Test username 2",
                    UserDescription = "Test user description 2",
                    ProfileImage = "Test profile image 2"
                }
            };
        }
    }
}
