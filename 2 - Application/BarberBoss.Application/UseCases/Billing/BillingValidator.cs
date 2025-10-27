using BarberBoss.Communication.Enums;
using BarberBoss.Communication.Request;
using BarberBoss.Exception;
using FluentValidation;

namespace BarberBoss.Application.UseCases.Billing
{
    public class BillingValidator : AbstractValidator<BillingRequest>
    {
        public BillingValidator()
        {
            

            RuleFor(billing => billing.BarberName)
                .NotNull().WithMessage(ResourceErrorMessages.BARBERNAME_REQUIRED)
                .NotEmpty().WithMessage(ResourceErrorMessages.BARBERNAME_REQUIRED)
                .MinimumLength(2).WithMessage(ResourceErrorMessages.BARBERNAME_LENGTH)
                .MaximumLength(80).WithMessage(ResourceErrorMessages.BARBERNAME_LENGTH);

            RuleFor(billing => billing.ClientName)
                .NotNull().WithMessage(ResourceErrorMessages.CLIENTNAME_REQUIRED)
                .NotEmpty().WithMessage(ResourceErrorMessages.CLIENTNAME_REQUIRED)
                .MinimumLength(2).WithMessage(ResourceErrorMessages.CLIENTNAME_LENGTH)
                .MaximumLength(120).WithMessage(ResourceErrorMessages.CLIENTNAME_LENGTH);

            RuleFor(billing => billing.ServiceName)
                .NotNull().WithMessage(ResourceErrorMessages.SERVICENAME_REQUIRED)
                .NotEmpty().WithMessage(ResourceErrorMessages.SERVICENAME_REQUIRED)
                .MinimumLength(2).WithMessage(ResourceErrorMessages.SERVICENAME_LENGTH)
                .MaximumLength(120).WithMessage(ResourceErrorMessages.SERVICENAME_LENGTH);

            RuleFor(billing => billing.Amount)
                .GreaterThanOrEqualTo(0)
                .WithMessage(ResourceErrorMessages.AMOUNT_RANGE);

            RuleFor(billing => billing.PaymentMethod)
                .IsInEnum()
                .WithMessage(ResourceErrorMessages.PAYMENTMETHOD_REQUIRED);

            RuleFor(billing => billing.Status)
                .IsInEnum()
                .WithMessage(ResourceErrorMessages.STATUS_INVALID);

            RuleFor(billing => billing.Notes)
                .MaximumLength(500)
                .WithMessage(ResourceErrorMessages.NOTES_LENGTH);

            // Regra especial: se status = Canceled, amount deve ser 0
            RuleFor(billing => billing)
                .Must(i => i.Status != BillingStatus.Canceled || i.Amount == 0)
                .WithMessage(ResourceErrorMessages.AMOUNT_RANGE);
        }
    }
}
