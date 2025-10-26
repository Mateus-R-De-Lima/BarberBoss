namespace BarberBoss.Domain
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
