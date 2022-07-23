using Administrator.Domain.Portfolio;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Administrator.Infrastructure.Persistence
{
    public class PortfolioDbContextSeedData
    {
        public static async Task LoadDataAsync(PortfolioDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var skills = new List<Skill>();

                if (!context.UsersInfo!.Any())
                {
                    var userInfoData = File.ReadAllText("../Administrator.Infrastructure/Data/userInfo.json");
                    var usersInfo = JsonSerializer.Deserialize<List<UserInfo>>(userInfoData);

                    await context.UsersInfo!.AddRangeAsync(usersInfo!);
                    await context.SaveChangesAsync();
                }

                if (!context.Skills!.Any())
                {
                    var skillData = File.ReadAllText("../Administrator.Infrastructure/Data/skill.json");
                    skills = JsonSerializer.Deserialize<List<Skill>>(skillData);

                    await GetPreconfiguredSkillsUserInfoAsync(skills!, context);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<PortfolioDbContextSeedData>();
                logger.LogError(ex.Message);
            }
        }

        private static async Task GetPreconfiguredSkillsUserInfoAsync(List<Skill> skills, PortfolioDbContext context)
        {
            var random = new Random();

            foreach (var skill in skills)
            {
                skill.UserInfoId = random.Next(1, 5);
            }

            await context.Skills!.AddRangeAsync(skills);
        }
    }
}
