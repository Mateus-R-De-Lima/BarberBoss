using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Response
{
    public class InvoiceShortResponse
    {
        public Guid Id { get; set; }

        public string ClientName { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public decimal Amount { get; set; }
        public InvoiceStatus Status { get; set; }
    }
}
