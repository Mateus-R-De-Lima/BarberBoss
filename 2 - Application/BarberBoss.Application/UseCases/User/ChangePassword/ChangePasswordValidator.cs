using BarberBoss.Application.UseCases.User.PassordValidator;
using BarberBoss.Communication.Request;
using FluentValidation;

namespace BarberBoss.Application.UseCases.User.ChangePassword
{
    public class ChangePasswordValidator : AbstractValidator<RequestChangePassword>
    {
        public ChangePasswordValidator()
        {
           RuleFor(p => p.NewPassword).SetValidator(new PassordValidator<RequestChangePassword>());
        }
    }
}
