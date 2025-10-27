using BarberBoss.Communication.Response;

namespace BarberBoss.Application.UseCases.Billing.GetAll
{
    public interface IGetAllBillingsUseCase
    {
        Task<ListBillingsResponse> Execute();
    }
}