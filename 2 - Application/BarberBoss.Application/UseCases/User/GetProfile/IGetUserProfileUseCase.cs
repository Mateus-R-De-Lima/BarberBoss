using BarberBoss.Communication.Response;

namespace BarberBoss.Application.UseCases.User.GetProfile
{
    public interface IGetUserProfileUseCase
    {
        Task<ResponseUserProfile> Execute();
    }
}