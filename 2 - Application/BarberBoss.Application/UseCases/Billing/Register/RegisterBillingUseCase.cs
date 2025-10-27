using AutoMapper;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using BarberBoss.Domain;
using BarberBoss.Domain.Repositories.Billings;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Billing.Register
{
    public class RegisterBillingUseCase(IBillingsWriteOnlyRepository repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork) : IRegisterBillingUseCase
    {

        public async Task<BillingResponse> Execute(BillingRequest request)
        {
            Validate(request);

            var entity = mapper.Map<Domain.Entities.Billing>(request);

            await repository.Add(entity);
            await unitOfWork.Commit();

            var response = mapper.Map<BillingResponse>(entity);

            return response;
        }

        private void Validate(BillingRequest request)
        {
            var validator = new BillingValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(i => i.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
