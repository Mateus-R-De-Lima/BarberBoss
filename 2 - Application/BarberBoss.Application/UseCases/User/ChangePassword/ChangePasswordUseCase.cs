using BarberBoss.Application.UseCases.LoggerUser;
using BarberBoss.Communication.Request;
using BarberBoss.Domain;
using BarberBoss.Domain.Repositories.User;
using BarberBoss.Domain.Security.Cryptography;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.User.ChangePassword
{
    public class ChangePasswordUseCase(ILoggerUser loggerUser,
                                       IUserUpdateOnlyRepository userUpdateOnlyRepository,
                                       IUnitOfWork unitOfWork,
                                       IPasswordEncripter passwordEncripter) : IChangePasswordUseCase
    {
        public async Task Execute(RequestChangePassword request)
        {
            var loggedUser = await loggerUser.Get();

            Validate(request, loggedUser);
            // Buscar usuário no banco de dados
            var user = await userUpdateOnlyRepository.GetById(loggedUser.Id);
            // Atualizar a senha do usuário
            user.PasswordHash = passwordEncripter.Encrypt(request.NewPassword);
            // Atualizar a data de atualização
            user.UpdatedAt = DateTime.UtcNow;
            // Montar a query de atualização
            userUpdateOnlyRepository.Update(user);
            // Salvar as alterações no banco de dados
            await unitOfWork.Commit();
        }
        /// <summary>
        /// Esse metodo valida os dados do request de alteração de senha.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="loggedUser"></param>
        /// <exception cref="ErrorOnValidationException"></exception>
        private void Validate(RequestChangePassword request, Domain.Entities.User loggedUser)
        {
            var result = new ChangePasswordValidator().Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(i => i.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }

            var passwordMatch = passwordEncripter.Verify(request.Password, loggedUser.PasswordHash);

            if (!passwordMatch)
                throw new ErrorOnValidationException([ResourceErrorMessages.PASSWORD_DIFFERENT_CURRENT_PASSWORD]);
        }
    }
}
