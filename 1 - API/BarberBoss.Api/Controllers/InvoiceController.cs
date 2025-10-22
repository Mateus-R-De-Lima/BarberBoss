using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(InvoiceResponse),StatusCodes.Status201Created)]
        public async Task<IActionResult> PostInvoice([FromBody] InvoiceRequest request)
        {
            var response = new InvoiceResponse
            {
                Id = Guid.NewGuid(),
                Date = request.Date,
                BarberName = request.BarberName,
                ClientName = request.ClientName,
                ServiceName = request.ServiceName,
                Amount = request.Amount,
                PaymentMethod = request.PaymentMethod,
                Status = request.Status,
                Notes = request.Notes,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return Created(string.Empty,response);
        }
    }
}
