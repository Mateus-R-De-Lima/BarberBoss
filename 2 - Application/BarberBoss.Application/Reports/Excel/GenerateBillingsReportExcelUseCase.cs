using BarberBoss.Domain.Enums;
using BarberBoss.Domain.Repositories.Billings;
using ClosedXML.Excel;

namespace BarberBoss.Application.Reports.Excel
{
    public class GenerateBillingsReportExcelUseCase(IBillingsReadOnlyRepository repository)
    {
        private const string CURRENCY_SYMBOL = "R$";

        public async Task<byte[]> Execute(DateOnly month)
        {
            var billings = await repository.FilterByMonth(month);
            if (billings.Count == 0)
                return [];

            using var workbook = new XLWorkbook();

            // Configuração 
            workbook.Author = "Mateus Lima";
            workbook.Style.Font.FontSize = 12;
            workbook.Style.Font.FontName = "Times New Roman";

            // Pagina
            var worksheet = workbook.Worksheets.Add(month.ToString("Y"));
            InsertHeader(worksheet);

            var raw = 2;
            foreach (var billing in billings)
            {
                worksheet.Cell($"A{raw}").Value = billing.ServiceName;
                worksheet.Cell($"B{raw}").Value = billing.Date.ToString();
                worksheet.Cell($"C{raw}").Value = ConvertPaymentType(billing.PaymentMethod);
                worksheet.Cell($"D{raw}").Value = billing.Amount;
                worksheet.Cell($"D{raw}").Style.NumberFormat.Format = $"-{CURRENCY_SYMBOL} #,##0.00";

                worksheet.Cell($"E{raw}").Value = billing.Notes;
                raw++;
            }

            var file = new MemoryStream();

            workbook.SaveAs(file);

            return file.ToArray();
        }

        private string ConvertPaymentType(PaymentMethod payment)
        {
            return payment switch
            {
                PaymentMethod.Cash => ResourceReportGenerationMessages.CASH,
                PaymentMethod.CreditCard => ResourceReportGenerationMessages.CREDITCARD,
                PaymentMethod.DebitCard => ResourceReportGenerationMessages.DEBITCARD,
                PaymentMethod.Pix => ResourceReportGenerationMessages.PIX,                
                _ => ResourceReportGenerationMessages.OTHER
            };

        }

        private void InsertHeader(IXLWorksheet worksheet)
        {
            worksheet.Cell("A1").Value = ResourceReportGenerationMessages.TITLE;
            worksheet.Cell("B1").Value = ResourceReportGenerationMessages.DATE;
            worksheet.Cell("C1").Value = ResourceReportGenerationMessages.PAYMENT_TYPE;
            worksheet.Cell("D1").Value = ResourceReportGenerationMessages.AMOUNT;
            worksheet.Cell("E1").Value = ResourceReportGenerationMessages.DESCRIPTION;
            // Font em Negrito
            worksheet.Cells("A1:E1").Style.Font.Bold = true;
            // BackgroundColor
            worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#F5C2B6");
            // Alinhamento
            worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);


        }
    }
}

