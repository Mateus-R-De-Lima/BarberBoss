using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using BarberBoss.Domain.Repositories.User;
using BarberBoss.Domain.Security.Cryptography;
using BarberBoss.Domain.Security.Token;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.User.DoLogin
{
    public class DoLoginUseCase(
        IUserReadOnlyRepository userReadOnlyRepository,
        IPasswordEncripter passwordEncripter,
        IAccessTokenGenarator accessTokenGenarator) : IDoLoginUseCase
    {

        public async Task<ResponseRegisteredUser> Execute(RequestLogin request)
        {
            var user = await userReadOnlyRepository.GetUserByEmail(request.Email);

            if (user is null)
                throw new InvalidLoginException(ResourceErrorMessages.EMAIL_OR_PASSWORD_INVALID);

            var isPasswordValid = passwordEncripter.Verify(request.Password, user.PasswordHash);

            if (!isPasswordValid)
                throw new InvalidLoginException(ResourceErrorMessages.EMAIL_OR_PASSWORD_INVALID);

            return new ResponseRegisteredUser
            {
                Name = user.Username,
                Token = accessTokenGenarator.Generate(user)
            };
        }
    }
}
