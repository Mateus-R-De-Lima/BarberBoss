using BarberBoss.Communication.Response;

namespace BarberBoss.Application.UseCases.Billing.GetById
{
    public interface IGetByIdBillingUseCase
    {
        Task<BillingResponse> Execute(Guid id);
    }
}