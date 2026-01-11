using BarberBoss.Communication.Request;

namespace BarberBoss.Application.UseCases.User.ChangePassword
{
    public interface IChangePasswordUseCase
    {
        Task Execute(RequestChangePassword request);
    }
}