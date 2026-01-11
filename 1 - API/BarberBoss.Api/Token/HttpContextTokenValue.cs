using BarberBoss.Domain.Security.Token;

namespace BarberBoss.Api.Token
{
    public class HttpContextTokenValue(IHttpContextAccessor httpContextAccessor) : ITokenProvider
    {
        /// <summary>
        /// Esse metodo recupera o token JWT do cabeçalho Authorization da requisição HTTP atual.
        /// </summary>
        /// <returns></returns>
        public string TokenOnRequest()
        {
            // Recupera o valor do cabeçalho Authorization da requisição HTTP atual
            var authorizationHeader = httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            // Remove o prefixo "Bearer " do cabeçalho para obter apenas o token
            return authorizationHeader["Bearer ".Length..].Trim();
        }
    }
}
