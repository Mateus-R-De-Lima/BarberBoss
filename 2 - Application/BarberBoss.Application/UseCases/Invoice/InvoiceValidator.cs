using BarberBoss.Communication.Enums;
using BarberBoss.Communication.Request;
using BarberBoss.Exception;
using FluentValidation;

namespace BarberBoss.Application.UseCases.Invoice
{
    public class InvoiceValidator : AbstractValidator<InvoiceRequest>
    {
        public InvoiceValidator()
        {
            

            RuleFor(invoice => invoice.BarberName)
                .NotNull().WithMessage(ResourceErrorMessages.BARBERNAME_REQUIRED)
                .NotEmpty().WithMessage(ResourceErrorMessages.BARBERNAME_REQUIRED)
                .MinimumLength(2).WithMessage(ResourceErrorMessages.BARBERNAME_LENGTH)
                .MaximumLength(80).WithMessage(ResourceErrorMessages.BARBERNAME_LENGTH);

            RuleFor(invoice => invoice.ClientName)
                .NotNull().WithMessage(ResourceErrorMessages.CLIENTNAME_REQUIRED)
                .NotEmpty().WithMessage(ResourceErrorMessages.CLIENTNAME_REQUIRED)
                .MinimumLength(2).WithMessage(ResourceErrorMessages.CLIENTNAME_LENGTH)
                .MaximumLength(120).WithMessage(ResourceErrorMessages.CLIENTNAME_LENGTH);

            RuleFor(invoice => invoice.ServiceName)
                .NotNull().WithMessage(ResourceErrorMessages.SERVICENAME_REQUIRED)
                .NotEmpty().WithMessage(ResourceErrorMessages.SERVICENAME_REQUIRED)
                .MinimumLength(2).WithMessage(ResourceErrorMessages.SERVICENAME_LENGTH)
                .MaximumLength(120).WithMessage(ResourceErrorMessages.SERVICENAME_LENGTH);

            RuleFor(invoice => invoice.Amount)
                .GreaterThanOrEqualTo(0)
                .WithMessage(ResourceErrorMessages.AMOUNT_RANGE);

            RuleFor(invoice => invoice.PaymentMethod)
                .IsInEnum()
                .WithMessage(ResourceErrorMessages.PAYMENTMETHOD_REQUIRED);

            RuleFor(invoice => invoice.Status)
                .IsInEnum()
                .WithMessage(ResourceErrorMessages.STATUS_INVALID);

            RuleFor(invoice => invoice.Notes)
                .MaximumLength(500)
                .WithMessage(ResourceErrorMessages.NOTES_LENGTH);

            // Regra especial: se status = Canceled, amount deve ser 0
            RuleFor(invoice => invoice)
                .Must(i => i.Status != InvoiceStatus.Canceled || i.Amount == 0)
                .WithMessage(ResourceErrorMessages.AMOUNT_RANGE);
        }
    }
}
