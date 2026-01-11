using BarberBoss.Application.UseCases.LoggerUser;
using BarberBoss.Domain;
using BarberBoss.Domain.Repositories.User;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.User.Delete
{
    public class DeleteProfileUserUseCase(ILoggerUser loggerUser,
                                          IUserWriteOnlyRepository userWriteOnlyRepository,
                                          IUnitOfWork unitOfWork) : IDeleteProfileUserUseCase
    {
        public async Task Execute()
        {

            var loggedUser = await loggerUser.Get();

            if (loggedUser is null)
                throw new NotFoundException(ResourceErrorMessages.USER_NOT_FOUND);

            await userWriteOnlyRepository.Delete(loggedUser);
            await unitOfWork.Commit();
        }
    }
}
