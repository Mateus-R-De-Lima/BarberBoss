using AutoMapper;
using BarberBoss.Application.UseCases.LoggerUser;
using BarberBoss.Communication.Response;

namespace BarberBoss.Application.UseCases.User.GetProfile
{
    public class GetUserProfileUseCase(ILoggerUser loggerUser, IMapper mapper) : IGetUserProfileUseCase
    {
        /// <summary>
        /// Esse metodo recupera o perfil do usuário logado.
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseUserProfile> Execute()
        {
            // Recupera o usuário logado
            var user = await loggerUser.Get();

            // Mapeia a entidade do usuário para o objeto de resposta
            var response = mapper.Map<ResponseUserProfile>(user);
            // Retorna o perfil do usuário
            return response;
        }
    }
}
