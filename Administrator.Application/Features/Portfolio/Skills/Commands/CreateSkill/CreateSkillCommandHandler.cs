using Administrator.Application.Contracts.Infrastructure;
using Administrator.Application.Contracts.Persistence;
using Administrator.Application.Models;
using Administrator.Domain.Portfolio;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Administrator.Application.Features.Portfolio.Skills.Commands.CreateSkill
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateSkillCommandHandler> _logger;

        public CreateSkillCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, ILogger<CreateSkillCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skillEntity = _mapper.Map<Skill>(request);

            _unitOfWork.Repository<Skill>().AddEntity(skillEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                _logger.LogError("Skill not created");
                throw new Exception("Skill not created");
            }

            _logger.LogInformation($"Skill {skillEntity.Id} created succesful");

            await SendEmail(skillEntity);

            return skillEntity.Id;
        }

        private async Task SendEmail(Skill skill)
        {
            var email = new Email
            {
                To = "test@email.com",
                Body = "Skill creado correctamente",
                Subject = "Skill creada"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errors sending email {skill.Id}");
            }
        }
    }
}
