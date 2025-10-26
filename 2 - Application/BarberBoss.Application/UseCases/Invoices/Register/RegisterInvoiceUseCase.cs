using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using BarberBoss.Domain;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Enums;
using BarberBoss.Domain.Repositories.Invoices;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Invoices.Register
{
    public class RegisterInvoiceUseCase(IInvoicesWriteOnlyRepository repository,IUnitOfWork unitOfWork) : IRegisterInvoiceUseCase
    {

        public async Task<InvoiceResponse> Execute(InvoiceRequest request)
        {
            Validate(request);

            var entity = new Invoice
            {
                Amount = request.Amount,
                BarberName = request.BarberName,
                ClientName = request.ClientName,
                Notes = request.Notes,
                PaymentMethod = (PaymentMethod)request.PaymentMethod,
                Status = (InvoiceStatus)request.Status,
                ServiceName = request.ServiceName,
                CreatedAt = DateTime.UtcNow,
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                UpdatedAt = DateTime.UtcNow,
                Id = Guid.NewGuid()

            };

            await repository.Add(entity);
            await unitOfWork.Commit();


            var response = new InvoiceResponse
            {
                Id = entity.Id,
                Date = entity.Date,
                BarberName = entity.BarberName,
                ClientName = entity.ClientName,
                ServiceName = entity.ServiceName,
                Amount = entity.Amount,   
                Notes = entity.Notes,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
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
