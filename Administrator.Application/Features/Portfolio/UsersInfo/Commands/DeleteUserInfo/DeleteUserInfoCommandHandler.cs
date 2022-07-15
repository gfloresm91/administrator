using Administrator.Application.Contracts.Persistence;
using Administrator.Application.Exceptions;
using Administrator.Domain.Portfolio;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Commands.DeleteUserInfo
{
    public class DeleteUserInfoCommandHandler : IRequestHandler<DeleteUserInfoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteUserInfoCommandHandler> _logger;

        public DeleteUserInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteUserInfoCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteUserInfoCommand request, CancellationToken cancellationToken)
        {
            var userInfoToDelete = await _unitOfWork.Repository<UserInfo>().GetByIdAsync(request.Id);

            if (userInfoToDelete == null)
            {
                _logger.LogError($"User info {request.Id} not found");
                throw new NotFoundException(nameof(UserInfo), request.Id);
            }

            _unitOfWork.Repository<UserInfo>().DeleteEntity(userInfoToDelete);

            await _unitOfWork.Complete();

            _logger.LogInformation($"User info {request.Id} deleted successful");

            return Unit.Value;
        }
    }
}
