using Administrator.Application.Contracts.Infrastructure;
using Administrator.Application.Contracts.Persistence.Portfolio;
using Administrator.Application.Models;
using Administrator.Domain.Portfolio;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Commands.CreateUserInfo
{
    public class CreateUserInfoCommandHandler : IRequestHandler<CreateUserInfoCommand, int>
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateUserInfoCommandHandler> _logger;

        public CreateUserInfoCommandHandler(IUserInfoRepository userInfoRepository, IMapper mapper, IEmailService emailService, ILogger<CreateUserInfoCommandHandler> logger)
        {
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateUserInfoCommand request, CancellationToken cancellationToken)
        {
            var userInfoEntity = _mapper.Map<UserInfo>(request);
            var newUserInfo = await _userInfoRepository.AddAsync(userInfoEntity);

            _logger.LogInformation($"User info {newUserInfo.Id} created succesful");

            await SendEmail(newUserInfo);

            return newUserInfo.Id;
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
