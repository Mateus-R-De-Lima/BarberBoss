using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Response
{
    public class InvoiceResponse
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public string BarberName { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public InvoiceStatus Status { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
