using BarberBoss.Communication.Request;

namespace BarberBoss.Application.UseCases.User.UpdateProfile
{
    public interface IUpdateUserProfileUseCase
    {
        Task Execute(RequestUpdateProfile request);
    }
}