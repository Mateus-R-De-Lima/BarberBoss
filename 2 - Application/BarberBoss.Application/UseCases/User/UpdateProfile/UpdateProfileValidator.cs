using BarberBoss.Communication.Request;
using BarberBoss.Exception;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss.Application.UseCases.User.UpdateProfile
{
    public class UpdateProfileValidator : AbstractValidator<RequestUpdateProfile>
    {

        public UpdateProfileValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);

            RuleFor(user => user.Email)
              .NotEmpty()
              .WithMessage(ResourceErrorMessages.EMAIL_EMPTY)
              .EmailAddress()
              .When(user => !string.IsNullOrWhiteSpace(user.Email), ApplyConditionTo.CurrentValidator)
              .WithMessage(ResourceErrorMessages.EMAIL_INVALID);

        }
    }
}
