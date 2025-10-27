using BarberBoss.Domain;
using BarberBoss.Domain.Repositories.Billings;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Billing.Delete
{
    public class DeleteBillingUseCase(IBillingsWriteOnlyRepository repository, IUnitOfWork unitOfWork) : IDeleteBillingUseCase
    {

        public async Task Execute(Guid id)
        {
            var result = await repository.Delete(id);
            if (result.Equals(false))
                throw new NotFoundException(ResourceErrorMessages.BILLING_NOT_FOUND);

            await unitOfWork.Commit();

        }
    }
}
