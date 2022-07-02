﻿using Administrator.Application.Contracts.Persistence.Portfolio;
using Administrator.Application.Exceptions;
using Administrator.Domain.Portfolio;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Commands.DeleteUserInfo
{
    public class DeleteUserInfoCommandHandler : IRequestHandler<DeleteUserInfoCommand>
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteUserInfoCommandHandler> _logger;

        public DeleteUserInfoCommandHandler(IUserInfoRepository userInfoRepository, IMapper mapper, ILogger<DeleteUserInfoCommandHandler> logger)
        {
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteUserInfoCommand request, CancellationToken cancellationToken)
        {
            var userInfoToDelete = await _userInfoRepository.GetByIdAsync(request.Id);

            if (userInfoToDelete == null)
            {
                _logger.LogError($"User info {request.Id} not found");
                throw new NotFoundException(nameof(UserInfo), request.Id);
            }

            await _userInfoRepository.DeleteAsync(userInfoToDelete);

            _logger.LogInformation($"User info {request.Id} deleted successful");

            return Unit.Value;
        }
    }
}
