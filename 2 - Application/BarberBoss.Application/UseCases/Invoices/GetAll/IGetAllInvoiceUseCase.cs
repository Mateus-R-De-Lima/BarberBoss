using BarberBoss.Communication.Response;

namespace BarberBoss.Application.UseCases.Invoices.GetAll
{
    public interface IGetAllInvoiceUseCase
    {
        Task<ListInvoiceResponse> Execute();
    }
}