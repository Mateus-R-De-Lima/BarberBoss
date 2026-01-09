using AutoMapper;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using BarberBoss.Domain;
using BarberBoss.Domain.Repositories.User;
using BarberBoss.Domain.Security.Cryptography;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.User.Register
{
    public class RegisterUserUseCase(IMapper mapper,
        IUnitOfWork unitOfWork,
        IPasswordEncripter passwordEncripter,
        IUserReadOnlyRepository userReadOnlyRepository,
        IUserWriteOnlyRepository userWriteOnlyRepository
        ) : IRegisterUserUseCase
    {

        public async Task<ResponseRegisteredUser> Execute(RequestUser request)
        {
            await Validate(request);

            var userEntity = mapper.Map<Domain.Entities.User>(request);

            userEntity.PasswordHash = passwordEncripter.Encrypt(request.Password);
            userEntity.UpdatedAt = DateTime.UtcNow;
            userEntity.CreatedAt = DateTime.UtcNow;

            await userWriteOnlyRepository.Add(userEntity);

            await unitOfWork.Commit();

            return new ResponseRegisteredUser
            {
                Name = request.Name,
                Token = "fake-jwt"
            };
        }

        private async Task Validate(RequestUser request)
        {
            var result = new RegisterUserValidator().Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(i => i.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }

            var emailExist = await userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

            if (emailExist)
                throw new ErrorOnValidationException([ResourceErrorMessages.EMAIL_ALREADY_REGISTERED]);
        }
    }
}
