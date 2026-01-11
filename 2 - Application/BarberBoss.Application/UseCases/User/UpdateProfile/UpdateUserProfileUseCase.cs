using BarberBoss.Application.UseCases.LoggerUser;
using BarberBoss.Communication.Request;
using BarberBoss.Domain;
using BarberBoss.Domain.Repositories.User;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace BarberBoss.Application.UseCases.User.UpdateProfile
{
    public class UpdateUserProfileUseCase(ILoggerUser loggerUser,
        IUserReadOnlyRepository userReadOnlyRepository,
        IUserUpdateOnlyRepository userUpdateOnlyRepository,
        IUnitOfWork unitOfWork) : IUpdateUserProfileUseCase
    {
        /// <summary>
        /// Esse metodo atualiza o perfil do usuário logado.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task Execute(RequestUpdateProfile request)
        {
            // Recupera o usuário logado
            var user = await loggerUser.Get();
            // Valida os dados do request
            await Validate(request, user.Email);
            // Recupera a entidade do usuário no banco de dados
            var userEntity = await userReadOnlyRepository.GetUserById(user.Id);
            // Atualiza os dados do usuário
            userEntity!.Username = request.Name;
            userEntity.Email = request.Email;
            userEntity.UpdatedAt = DateTime.UtcNow;
            // Monta a query de atualização
            userUpdateOnlyRepository.Update(userEntity);
            // Salva as alterações no banco de dados
            await unitOfWork.Commit();

        }
        /// <summary>
        /// Valida os dados do request de atualização de perfil.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="ErrorOnValidationException"></exception>
        private async Task Validate(RequestUpdateProfile request, string email)
        {
            //Cria um instancia do validador
            var validator = new UpdateProfileValidator();
            //Executa a validação
            var result = validator.Validate(request);
            //Verifica se o email do request é diferente do email atual do usuário
            if (!email.Equals(request.Email, StringComparison.OrdinalIgnoreCase))
            {
                //Verifica se já existe um usuário ativo com o email informado
                var userExist = await userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
                //Se existir, adiciona um erro na validação
                if (userExist)
                    result.Errors.Add(new ValidationFailure("Email", ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
            }

            if (!result.IsValid)
            {
                //Se a validação falhar, lança uma exceção com os erros encontrados
                var errorMessages = result.Errors.Select(i => i.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
