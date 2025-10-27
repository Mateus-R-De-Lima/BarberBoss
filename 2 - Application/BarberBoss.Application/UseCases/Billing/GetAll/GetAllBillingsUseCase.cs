using AutoMapper;
using BarberBoss.Communication.Response;
using BarberBoss.Domain.Repositories.Billings;

namespace BarberBoss.Application.UseCases.Billing.GetAll
{
    public class GetAllBillingsUseCase(IBillingsReadOnlyRepository repository,
                                      IMapper mapper) : IGetAllBillingsUseCase
    {
        public async Task<ListBillingsResponse> Execute()
        {
            var result = await repository.GetAll();

            return new ListBillingsResponse
            {
                Billings = mapper.Map<List<BillingShortResponse>>(result)
            };

        }

    }
}
