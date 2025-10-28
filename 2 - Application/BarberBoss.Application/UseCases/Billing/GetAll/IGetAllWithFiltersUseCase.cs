using BarberBoss.Communication.Filter;
using BarberBoss.Communication.Response;

namespace BarberBoss.Application.UseCases.Billing.GetAll
{
    public interface IGetAllWithFiltersUseCase
    {
        Task<PagedResultResponse<BillingResponse?>> Execute(FilterRequest filter);
    }
}