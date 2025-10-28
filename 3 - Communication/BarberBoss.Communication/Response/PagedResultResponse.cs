namespace BarberBoss.Communication.Response
{
    public class PagedResultResponse<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public long TotalCount { get; set; }   // total de registros que satisfazem o filtro
        public int TotalPages { get; set;}
        public List<T> Items { get; set; } = new List<T>();
    }
}
