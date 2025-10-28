using AutoMapper;
using BarberBoss.Communication.Filter;
using BarberBoss.Communication.Response;
using BarberBoss.Domain.Filter;
using BarberBoss.Domain.Repositories.Billings;

namespace BarberBoss.Application.UseCases.Billing.GetAll
{
    public class GetAllWithFiltersUseCase(IBillingsReadOnlyRepository repository,
                                      IMapper mapper) : IGetAllWithFiltersUseCase
    {
        public async Task<PagedResultResponse<BillingResponse?>?> Execute(FilterRequest filter)
        {
            var result = await repository.GetAllWithFilters(mapper.Map<BillingFilter>(filter));

            if (result is null)
                return null;

            return new PagedResultResponse<BillingResponse?>
            {
                Items = mapper.Map<List<BillingResponse?>>(result.Items),
                Page = result.Page,
                PageSize = result.PageSize,
                TotalCount = result.TotalCount,
                TotalPages = result.TotalPages

            };

        }
    }
}
