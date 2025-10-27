using BarberBoss.Domain;

namespace BarberBoss.Infrastructure.DataAccess
{
    public class UnitOfWork(BillingDbContext dbContext) : IUnitOfWork
    {
        public async Task Commit() => await dbContext.SaveChangesAsync();
    }
}
