using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories.Invoices;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infrastructure.DataAccess.Repositories
{
    public class InvoicesRepository(InvoiceDbContext dbContext) : IInvoicesWriteOnlyRepository
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
    }
}
