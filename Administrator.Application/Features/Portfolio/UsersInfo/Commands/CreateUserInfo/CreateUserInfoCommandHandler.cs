using Administrator.Application.Contracts.Infrastructure;
using Administrator.Application.Contracts.Persistence;
using Administrator.Application.Models;
using Administrator.Domain.Portfolio;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Commands.CreateUserInfo
{
    public class CreateUserInfoCommandHandler : IRequestHandler<CreateUserInfoCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateUserInfoCommandHandler> _logger;

        public CreateUserInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, ILogger<CreateUserInfoCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateUserInfoCommand request, CancellationToken cancellationToken)
        {
            var userInfoEntity = _mapper.Map<UserInfo>(request);

            _unitOfWork.Repository<UserInfo>().AddEntity(userInfoEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                _logger.LogError("User info not created");
                throw new Exception("User info not created");
            }
            
            _logger.LogInformation($"User info {userInfoEntity.Id} created succesful");

            await SendEmail(userInfoEntity);

            return userInfoEntity.Id;
        }

        private async Task SendEmail(UserInfo userInfo)
        {
            var email = new Email
            {
                To = "test@email.com",
                Body = "Información del usuario creado correctamente",
                Subject = "Información de usuario creada"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errors sending email {userInfo.Id}");
            }
        }
    }
}
