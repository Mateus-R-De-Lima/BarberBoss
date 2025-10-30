using BarberBoss.Communication.Enums;
using BarberBoss.Communication.Request;
using Bogus;

namespace BarberBoss.CommonTestUtilities.Request
{
    public class RequestRegisterBillingBuilder
    {

        public static Faker<BillingRequest> Build()
        {

            return new Faker<BillingRequest>("pt_BR")
                .RuleFor(i => i.Date, f => DateOnly.FromDateTime(f.Date.Recent(30))) // Últimos 30 dias
                .RuleFor(i => i.BarberName, f => f.Name.FirstName() + " " + f.Name.LastName())
                .RuleFor(i => i.ClientName, f => f.Name.FullName())
                .RuleFor(i => i.ServiceName, f => f.PickRandom(new[] {
                    "Corte de Cabelo", "Barba", "Corte + Barba", "Sobrancelha", "Hidratação Capilar"
                }))
                .RuleFor(i => i.Amount, f => f.Random.Decimal(30, 150))
                .RuleFor(i => i.PaymentMethod, f => f.PickRandom<PaymentMethod>())
                .RuleFor(i => i.Status, f => f.PickRandom<BillingStatus>())
                .RuleFor(i => i.Notes, f => f.Random.Bool(0.3f) ? f.Lorem.Sentence() : null);
        }
    }

}
