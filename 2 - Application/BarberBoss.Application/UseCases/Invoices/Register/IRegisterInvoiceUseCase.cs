using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;

namespace BarberBoss.Application.UseCases.Invoices.Register
{
    public interface IRegisterInvoiceUseCase
    {
        Task<InvoiceResponse> Execute(InvoiceRequest request);
    }
}