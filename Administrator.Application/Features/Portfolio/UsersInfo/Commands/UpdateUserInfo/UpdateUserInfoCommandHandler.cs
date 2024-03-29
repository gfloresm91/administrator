﻿using Administrator.Application.Contracts.Persistence;
using Administrator.Application.Exceptions;
using Administrator.Domain.Portfolio;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Commands.UpdateUserInfo
{
    public class UpdateUserInfoCommandHandler : IRequestHandler<UpdateUserInfoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUserInfoCommandHandler> _logger;

        public UpdateUserInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateUserInfoCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
        {
            var userInfoToUpdate = await _unitOfWork.Repository<UserInfo>().GetByIdAsync(request.Id);

            if (userInfoToUpdate == null)
            {
                _logger.LogError($"User info {request.Id} not found");
                throw new NotFoundException(nameof(UserInfo), request.Id);
            }

            _mapper.Map(request, userInfoToUpdate, typeof(UpdateUserInfoCommand), typeof(UserInfo));

            _unitOfWork.Repository<UserInfo>().UpdateEntity(userInfoToUpdate);

            await _unitOfWork.Complete();

            _logger.LogInformation($"User info {request.Id} updated successful");

            return Unit.Value;
        }
    }
}
