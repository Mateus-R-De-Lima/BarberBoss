using AutoMapper;
using BarberBoss.Communication.Request;
using BarberBoss.Domain;
using BarberBoss.Domain.Repositories.Invoices;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Invoices.Update
{
    public class UpdateInvoiceUseCase(IIvoiceUpdateOnlyRepository repository,
                                      IMapper mapper,
                                      IUnitOfWork unitOfWork) : IUpdateInvoiceUseCase
    {

        public async Task Execute(Guid id, InvoiceRequest request)
        {
            Validate(request);

            var expense = await repository.GetById(id);

            if (expense is null)
                throw new NotFoundException(ResourceErrorMessages.INVOICE_NOT_FOUND);

            mapper.Map(request, expense);

            repository.Update(expense);

            await unitOfWork.Commit();
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
