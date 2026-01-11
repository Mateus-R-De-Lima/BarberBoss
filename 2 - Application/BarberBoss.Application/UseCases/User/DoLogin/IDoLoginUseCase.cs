using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;

namespace BarberBoss.Application.UseCases.User.DoLogin
{
    public interface IDoLoginUseCase
    {
        Task<ResponseRegisteredUser> Execute(RequestLogin request);
    }
}