using MediatR;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Commands.DeleteUserInfo
{
    public class DeleteUserInfoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
