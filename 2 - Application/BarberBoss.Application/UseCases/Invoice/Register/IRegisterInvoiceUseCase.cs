using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;

namespace BarberBoss.Application.UseCases.Invoice.Register
{
    public interface IRegisterInvoiceUseCase
    {
        Task<InvoiceResponse> Execute(InvoiceRequest request);
    }
}