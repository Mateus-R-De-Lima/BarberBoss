using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;

namespace BarberBoss.Application.UseCases.Invoice.Register
{
    public class RegisterInvoiceUseCase
    {

        public async Task<InvoiceResponse> Execute(InvoiceRequest request)
        {
            Validate(request);
        }

        private void Validate(InvoiceRequest request)
        {

        }
    }
}
