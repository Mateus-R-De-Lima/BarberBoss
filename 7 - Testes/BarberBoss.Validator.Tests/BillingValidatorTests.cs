using BarberBoss.Application.UseCases.Billing;
using BarberBoss.CommonTestUtilities.Request;
using BarberBoss.Communication.Enums;
using BarberBoss.Communication.Request;
using BarberBoss.Exception;
using Bogus;


namespace BarberBoss.Validator.Tests
{
    public class BillingValidatorTests
    {
        private readonly BillingValidator _validator;
        private readonly Faker<BillingRequest> _faker;

        public BillingValidatorTests()
        {
            _validator = new BillingValidator();
            _faker = RequestRegisterBillingBuilder.Build();
        }

        [Fact(DisplayName = "Billing válido não deve gerar erros")]
        public void Should_Pass_With_Valid_Billing()
        {
            var billing = _faker.Generate();

            var result = _validator.Validate(billing);

            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Theory(DisplayName = "BarberName inválido deve gerar erro")]
        [InlineData("")]
        [InlineData("A")]
        [InlineData(null)]
        [InlineData("Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void Should_Fail_When_BarberName_Invalid(string? name)
        {
            var billing = _faker.Generate();
            billing.BarberName = name ?? "";

            var result = _validator.Validate(billing);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.ErrorMessage.Contains(ResourceErrorMessages.BARBERNAME_REQUIRED) ||
                e.ErrorMessage.Contains(ResourceErrorMessages.BARBERNAME_LENGTH));
        }

        [Theory(DisplayName = "ClientName inválido deve gerar erro")]
        [InlineData("")]
        [InlineData("A")]
        [InlineData(null)]
        
        public void Should_Fail_When_ClientName_Invalid(string? name)
        {
            var billing = _faker.Generate();
            billing.ClientName = name ?? "";

            var result = _validator.Validate(billing);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.ErrorMessage.Contains(ResourceErrorMessages.CLIENTNAME_REQUIRED) ||
                e.ErrorMessage.Contains(ResourceErrorMessages.CLIENTNAME_LENGTH));
        }

        [Theory(DisplayName = "ServiceName inválido deve gerar erro")]
        [InlineData("")]
        [InlineData("A")]
        [InlineData(null)]     

        public void Should_Fail_When_ServiceName_Invalid(string? name)
        {
            var billing = _faker.Generate();
            billing.ServiceName = name ?? "";

            var result = _validator.Validate(billing);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.ErrorMessage.Contains(ResourceErrorMessages.SERVICENAME_REQUIRED) ||                
                e.ErrorMessage.Contains(ResourceErrorMessages.SERVICENAME_LENGTH));
        }

        [Fact(DisplayName = "Amount menor que zero deve gerar erro")]
        public void Should_Fail_When_Amount_IsNegative()
        {
            var billing = _faker.Generate();
            billing.Amount = -1;

            var result = _validator.Validate(billing);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.ErrorMessage.Contains(ResourceErrorMessages.AMOUNT_RANGE));
        }

        [Fact(DisplayName = "PaymentMethod inválido deve gerar erro")]
        public void Should_Fail_When_PaymentMethod_Invalid()
        {
            var billing = _faker.Generate();
            billing.PaymentMethod = (PaymentMethod)999;

            var result = _validator.Validate(billing);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.ErrorMessage.Contains(ResourceErrorMessages.PAYMENTMETHOD_REQUIRED));
        }

        [Fact(DisplayName = "Status inválido deve gerar erro")]
        public void Should_Fail_When_Status_Invalid()
        {
            var billing = _faker.Generate();
            billing.Status = (BillingStatus)999;

            var result = _validator.Validate(billing);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.ErrorMessage.Contains(ResourceErrorMessages.STATUS_INVALID));
        }

        [Fact(DisplayName = "Notes maiores que 500 caracteres devem gerar erro")]
        public void Should_Fail_When_Notes_TooLong()
        {
            var billing = _faker.Generate();
            billing.Notes = new string('A', 501);

            var result = _validator.Validate(billing);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.ErrorMessage.Contains(ResourceErrorMessages.NOTES_LENGTH));
        }

        [Fact(DisplayName = "Se status for Canceled e Amount diferente de 0 deve gerar erro")]
        public void Should_Fail_When_Canceled_And_Amount_NotZero()
        {
            var billing = _faker.Generate();
            billing.Status = BillingStatus.Canceled;
            billing.Amount = 10;

            var result = _validator.Validate(billing);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.ErrorMessage.Contains(ResourceErrorMessages.AMOUNT_RANGE));
        }

        [Fact(DisplayName = "Se status for Canceled e Amount = 0 deve ser válido")]
        public void Should_Pass_When_Canceled_And_Amount_Zero()
        {
            var billing = _faker.Generate();
            billing.Status = BillingStatus.Canceled;
            billing.Amount = 0;

            var result = _validator.Validate(billing);

            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }
    }
}

