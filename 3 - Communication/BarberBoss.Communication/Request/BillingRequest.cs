using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Request
{
    public class BillingRequest
    {
       
        public DateOnly Date { get; set; }       
        public string BarberName { get; set; } = string.Empty;      
        public string ClientName { get; set; } = string.Empty;      
        public string ServiceName { get; set; } = string.Empty;      
        public decimal Amount { get; set; }     
        public PaymentMethod PaymentMethod { get; set; }       
        public BillingStatus Status { get; set; }      
        public string? Notes { get; set; }
    }
}
