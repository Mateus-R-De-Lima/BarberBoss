using BarberBoss.Domain.Enums;

namespace BarberBoss.Domain.Filter
{
    public class BillingFilter
    {
        public string? BarberName { get; set; }
        public string? ClientName { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; } = 10;
        public BillingStatus? Status { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
