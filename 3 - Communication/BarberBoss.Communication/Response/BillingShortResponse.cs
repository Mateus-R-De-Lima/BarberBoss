using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Response
{
    public class BillingShortResponse
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public decimal Amount { get; set; }
        public BillingStatus Status { get; set; }
    }
}
