using BarberBoss.Application.UseCases.Invoice.Register;
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
    }
}
