using AutoMapper;
using BarberBoss.Communication.Response;
using BarberBoss.Domain.Repositories.Billings;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Billing.GetById
{
    public class GetByIdBillingUseCase(IBillingsReadOnlyRepository repository, IMapper mapper) : IGetByIdBillingUseCase
    {
        public async Task<BillingResponse> Execute(Guid id)
        {
            var result = await repository.GetById(id);

            if (result is null)
                throw new NotFoundException(ResourceErrorMessages.BILLING_NOT_FOUND);

            return mapper.Map<BillingResponse>(result);
        }
    }
}
