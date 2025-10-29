
namespace BarberBoss.Application.Reports.Excel
{
    public interface IGenerateBillingsReportExcelUseCase
    {
        Task<byte[]> Execute(DateOnly month);
    }
}