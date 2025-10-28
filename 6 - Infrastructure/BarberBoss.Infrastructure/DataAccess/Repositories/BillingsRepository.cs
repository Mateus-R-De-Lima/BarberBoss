using BarberBoss.Communication.Response;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Filter;
using BarberBoss.Domain.Repositories.Billings;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BarberBoss.Infrastructure.DataAccess.Repositories
{
    public class BillingsRepository(BillingDbContext dbContext) : IBillingsWriteOnlyRepository, IBillingsReadOnlyRepository, IBillingUpdateOnlyRepository
    {
        public async Task Add(Billing billing)
        {

            await dbContext.AddAsync(billing);
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await dbContext.Billings.FirstOrDefaultAsync(billing => billing.Id.Equals(id));
            if (result is null)
                return false;

            dbContext.Remove(result);
            return true;
        }

        public async Task<List<Billing>> FilterByMonth(DateOnly date)
        {
            var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;
            var daysInMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);
            var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth, hour: 23, minute: 59, second: 59);

            return await dbContext.Billings
               .AsNoTracking()
               .Where(expense => expense.CreatedAt >= startDate && expense.CreatedAt <= endDate)
               .OrderByDescending(expense => expense.CreatedAt)
               .ThenBy(expense => expense.BarberName)
               .ToListAsync();

        }

        public async Task<List<Billing>> GetAll()
        {
            return await dbContext.Billings.AsNoTracking().OrderByDescending(createAt => createAt.CreatedAt).ToListAsync();
        }

         async Task<Billing?> IBillingsReadOnlyRepository.GetById(Guid id)
        {
            return await dbContext.Billings.AsNoTracking().FirstOrDefaultAsync(billing => billing.Id.Equals(id));
        }

        async Task<Billing?> IBillingUpdateOnlyRepository.GetById(Guid id)
        {
            return await dbContext.Billings.FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Update(Billing expense)
        {
            dbContext.Billings.Update(expense);
        }

        public async Task<PagedResult<Billing?>> GetAllWithFilters(BillingFilter filter)
        {
            IQueryable<Billing> query = dbContext.Billings.AsNoTracking();

            //  Filtros dinâmicos
            if (!string.IsNullOrWhiteSpace(filter.BarberName))
                query = query.Where(i => i.BarberName.Contains(filter.BarberName));

            if (!string.IsNullOrWhiteSpace(filter.ClientName))
                query = query.Where(i => i.ClientName.Contains(filter.ClientName));

            if (filter.Status is not null)
                query = query.Where(i => i.Status.Equals(filter.Status));

            if (filter.FromDate.HasValue)
                query = query.Where(i => i.CreatedAt >= filter.FromDate);

            if (filter.ToDate.HasValue)
                query = query.Where(i => i.CreatedAt <= filter.ToDate);

            // Total antes da paginação
            long totalCount = await query.LongCountAsync();

            //  Paginação
            var items = await query
                .OrderByDescending(i => i.Date) // ordenação padrão
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            if (items.Count < 0)
                return null;

            return new PagedResult<Billing?>
            {
                Items = items,
                Page = filter.Page,
                PageSize = filter.PageSize,
                TotalCount = totalCount
            };
        }
    }
    
}
