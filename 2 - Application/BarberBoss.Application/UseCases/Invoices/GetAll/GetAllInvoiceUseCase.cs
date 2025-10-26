using AutoMapper;
using BarberBoss.Communication.Response;
using BarberBoss.Domain.Repositories.Invoices;

namespace BarberBoss.Application.UseCases.Invoices.GetAll
{
    public class GetAllInvoiceUseCase(IInvoicesReadOnlyRepository repository,
                                      IMapper mapper) : IGetAllInvoiceUseCase
    {
        public async Task<ListInvoiceResponse> Execute()
        {
            var result = await repository.GetAll();

            return new ListInvoiceResponse
            {
                Invoices = mapper.Map<List<InvoiceShortResponse>>(result)
            };

        }

    }
}
