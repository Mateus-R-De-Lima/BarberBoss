using AutoMapper;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using BarberBoss.Domain;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Enums;
using BarberBoss.Domain.Repositories.Invoices;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Invoices.Register
{
    public class RegisterInvoiceUseCase(IInvoicesWriteOnlyRepository repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork) : IRegisterInvoiceUseCase
    {

        public async Task<InvoiceResponse> Execute(InvoiceRequest request)
        {
            Validate(request);

            var entity = mapper.Map<Invoice>(request);

            await repository.Add(entity);
            await unitOfWork.Commit();

            var response = mapper.Map<InvoiceResponse>(entity);

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
