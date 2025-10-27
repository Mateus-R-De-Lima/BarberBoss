using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;

namespace BarberBoss.Application.UseCases.Billing.Register
{
    public interface IRegisterBillingUseCase
    {
        Task<BillingResponse> Execute(BillingRequest request);
    }
}