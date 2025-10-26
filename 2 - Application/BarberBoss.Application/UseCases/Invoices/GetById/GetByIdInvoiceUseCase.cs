using AutoMapper;
using BarberBoss.Communication.Response;
using BarberBoss.Domain.Repositories.Invoices;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Invoices.GetById
{
    public class GetByIdInvoiceUseCase(IInvoicesReadOnlyRepository repository, IMapper mapper) : IGetByIdInvoiceUseCase
    {
        public async Task<InvoiceResponse> Execute(Guid id)
        {
            var result = await repository.GetById(id);

            if (result is null)
                throw new NotFoundException(ResourceErrorMessages.INVOICE_NOT_FOUND);

            return mapper.Map<InvoiceResponse>(result);
        }
    }
}
