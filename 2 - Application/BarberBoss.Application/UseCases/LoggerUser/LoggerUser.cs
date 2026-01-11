using BarberBoss.Domain.Repositories.User;
using BarberBoss.Domain.Security.Token;
using System.IdentityModel.Tokens.Jwt;


namespace BarberBoss.Application.UseCases.LoggerUser
{
    public class LoggerUser(IUserReadOnlyRepository userReadOnlyRepository, ITokenProvider tokenProvider)
    {
        public async Task<Domain.Entities.User> Get()
        {
            var token  = tokenProvider.TokenOnRequest();

            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtToken = tokenHandler.ReadJwtToken(token);

            var userIdClain = jwtToken.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Sid);

            return await userReadOnlyRepository.GetUserById(Guid.Parse(userIdClain!.Value));
        }
    }
}
