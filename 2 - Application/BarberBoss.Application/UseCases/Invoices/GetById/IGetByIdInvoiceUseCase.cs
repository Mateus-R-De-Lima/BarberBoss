using BarberBoss.Communication.Response;

namespace BarberBoss.Application.UseCases.Invoices.GetById
{
    public interface IGetByIdInvoiceUseCase
    {
        Task<InvoiceResponse> Execute(Guid id);
    }
}