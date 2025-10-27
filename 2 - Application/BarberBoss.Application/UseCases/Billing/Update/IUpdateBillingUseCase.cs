using BarberBoss.Communication.Request;

namespace BarberBoss.Application.UseCases.Billing.Update
{
    public interface IUpdateBillingUseCase
    {
        Task Execute(Guid id, BillingRequest request);
    }
}