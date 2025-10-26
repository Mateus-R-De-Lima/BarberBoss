using BarberBoss.Application.UseCases.Invoices.GetAll;
using BarberBoss.Application.UseCases.Invoices.Register;
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
        public async Task<IActionResult> PostInvoice([FromServices] IRegisterInvoiceUseCase registerInvoiceUseCase,[FromBody] InvoiceRequest request)
        {
            var response = await registerInvoiceUseCase.Execute(request);

            return Created(string.Empty,response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ListInvoiceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllInvoice([FromServices] IGetAllInvoiceUseCase getAllInvoiceUseCase)
        {
            var result = await getAllInvoiceUseCase.Execute();

            if (result.Invoices.Count > 0 && result is not null)
                return Ok(result);

            return NoContent();

        }
    }
}
