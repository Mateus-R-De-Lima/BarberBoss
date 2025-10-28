using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Filter
{
    public class FilterRequest
    {
        public string? BarberName { get; set; }
        public string? ClientName { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public BillingStatus? Status { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
