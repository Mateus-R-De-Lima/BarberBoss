using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Invoice.Register
{
    public class RegisterInvoiceUseCase : IRegisterInvoiceUseCase
    {

        public async Task<InvoiceResponse> Execute(InvoiceRequest request)
        {
            Validate(request);

            var response = new InvoiceResponse
            {
                Id = Guid.NewGuid(),
                Date = request.Date,
                BarberName = request.BarberName,
                ClientName = request.ClientName,
                ServiceName = request.ServiceName,
                Amount = request.Amount,
                PaymentMethod = request.PaymentMethod,
                Status = request.Status,
                Notes = request.Notes,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return response;
        }

        private void Validate(InvoiceRequest request)
        {
            var validator = new InvoiceValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(i => i.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
