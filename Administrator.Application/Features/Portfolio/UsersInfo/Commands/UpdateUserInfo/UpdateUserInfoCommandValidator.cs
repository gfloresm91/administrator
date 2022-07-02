using FluentValidation;

namespace Administrator.Application.Features.Portfolio.UsersInfo.Commands.UpdateUserInfo
{
    public class UpdateUserInfoCommandValidator : AbstractValidator<UpdateUserInfoCommand>
    {
        public UpdateUserInfoCommandValidator()
        {
            RuleFor(p => p.UserName)
               .NotEmpty().WithMessage("{UserName} es requerido")
               .NotNull()
               .MaximumLength(255).WithMessage("{UserName} no puede tener mas de 255 caracteres");

            RuleFor(p => p.ProfileImage)
                .NotEmpty().WithMessage("{ProfileImage} es requerido")
                .NotNull();

            RuleFor(p => p.UserDescription)
               .NotEmpty().WithMessage("{UserDescription} es requerido")
               .NotNull()
               .MaximumLength(255).WithMessage("{UserDescription} no puede tener mas de 255 caracteres");
        }
    }
}
