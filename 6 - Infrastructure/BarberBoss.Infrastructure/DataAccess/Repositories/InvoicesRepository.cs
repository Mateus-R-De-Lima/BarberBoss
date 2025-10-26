using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories.Invoices;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infrastructure.DataAccess.Repositories
{
    public class InvoicesRepository(InvoiceDbContext dbContext) : IInvoicesWriteOnlyRepository, IInvoicesReadOnlyRepository
    {
        public async Task Add(Invoice invoice)
        {
            
           await dbContext.AddAsync(invoice);
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await dbContext.Invoices.FirstOrDefaultAsync(invoice => invoice.Id.Equals(id));
            if(result is null)
                return false;

            dbContext.Remove(result);
            return true;
        }

        public async  Task<List<Invoice>> FilterByMonth(DateOnly date)
        {
            var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;
            var daysInMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);
            var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth, hour: 23, minute: 59, second: 59);

            return await dbContext.Invoices
               .AsNoTracking()
               .Where(expense => expense.CreatedAt >= startDate && expense.CreatedAt <= endDate)
               .OrderByDescending(expense => expense.CreatedAt)
               .ThenBy(expense => expense.BarberName)
               .ToListAsync();

        }

        public async Task<List<Invoice>> GetAll()
        {
            return await dbContext.Invoices.AsNoTracking().OrderByDescending(createAt => createAt.CreatedAt) .ToListAsync();
        }

        public async Task<Invoice?> GetById(Guid id)
        {
            return await dbContext.Invoices.AsNoTracking().FirstOrDefaultAsync(invoice => invoice.Id.Equals(id));
        }
    }
}
