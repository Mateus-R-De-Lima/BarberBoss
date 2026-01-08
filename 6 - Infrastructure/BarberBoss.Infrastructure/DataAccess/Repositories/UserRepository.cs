using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infrastructure.DataAccess.Repositories
{
    internal class UserRepository(BillingDbContext dbContext) : IUserReadOnlyRepository, IUserUpdateOnlyRepository, IUserWriteOnlyRepository
    {
        public async Task Add(User user)
        {
            await dbContext.Users.AddAsync(user);
        }

        public async Task Delete(User user)
        {
            var userToRemove = await dbContext.Users.FindAsync(user.Id);
            dbContext.Remove(userToRemove!);
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
           return await dbContext.Users.AnyAsync(user => user.Email.Equals(email));
        }

        public async Task<User> GetById(Guid id)
        {
            return await dbContext.Users.FirstAsync(user => user.Id == id);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public void Update(User user)
        {
           dbContext.Users.Update(user);
        }
    }
}
