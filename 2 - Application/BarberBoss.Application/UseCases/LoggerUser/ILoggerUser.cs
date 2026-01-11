





namespace BarberBoss.Application.UseCases.LoggerUser
{
    public interface ILoggerUser
    {
        Task<Domain.Entities.User> Get();
    }
}