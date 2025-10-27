using AutoMapper;
using BarberBoss.Communication.Request;
using BarberBoss.Domain;
using BarberBoss.Domain.Repositories.Billings;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Billing.Update
{
    public class UpdateBillingUseCase(IBillingUpdateOnlyRepository repository,
                                      IMapper mapper,
                                      IUnitOfWork unitOfWork) : IUpdateBillingUseCase
    {

        public async Task Execute(Guid id, BillingRequest request)
        {
            Validate(request);

            var expense = await repository.GetById(id);

            if (expense is null)
                throw new NotFoundException(ResourceErrorMessages.BILLING_NOT_FOUND);

            mapper.Map(request, expense);

            repository.Update(expense);

            await unitOfWork.Commit();
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
