using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Security.Token
{
    public interface IAccessTokenGenarator
    {
        string Generate(User user);
    }
}
