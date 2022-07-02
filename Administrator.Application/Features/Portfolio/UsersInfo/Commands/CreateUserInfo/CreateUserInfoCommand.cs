using MediatR;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Commands.CreateUserInfo
{
    public class CreateUserInfoCommand : IRequest<int>
    {
        public string ProfileImage { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserDescription { get; set; } = string.Empty;
    }
}
