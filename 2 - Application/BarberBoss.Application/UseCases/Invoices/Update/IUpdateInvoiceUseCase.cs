using BarberBoss.Communication.Request;

namespace BarberBoss.Application.UseCases.Invoices.Update
{
    public interface IUpdateInvoiceUseCase
    {
        Task Execute(Guid id, InvoiceRequest request);
    }
}