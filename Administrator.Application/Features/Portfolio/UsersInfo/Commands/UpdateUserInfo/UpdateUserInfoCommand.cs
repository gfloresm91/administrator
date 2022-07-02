using MediatR;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Commands.UpdateUserInfo
{
    public class UpdateUserInfoCommand : IRequest
    {
        public int Id { get; set; }
        public string ProfileImage { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserDescription { get; set; } = string.Empty;
    }
}
