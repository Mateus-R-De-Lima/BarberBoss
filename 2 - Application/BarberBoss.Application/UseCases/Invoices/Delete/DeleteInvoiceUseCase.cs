using BarberBoss.Domain;
using BarberBoss.Domain.Repositories.Invoices;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Invoices.Delete
{
    public class DeleteInvoiceUseCase(IInvoicesWriteOnlyRepository repository, IUnitOfWork unitOfWork) : IDeleteInvoiceUseCase
    {

        public async Task Execute(Guid id)
        {
            var result = await repository.Delete(id);
            if (result.Equals(false))
                throw new NotFoundException(ResourceErrorMessages.INVOICE_NOT_FOUND);

            await unitOfWork.Commit();

        }
    }
}
