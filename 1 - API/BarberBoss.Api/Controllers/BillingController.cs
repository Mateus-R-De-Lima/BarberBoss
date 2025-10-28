using BarberBoss.Application.UseCases.Billing.Delete;
using BarberBoss.Application.UseCases.Billing.GetAll;
using BarberBoss.Application.UseCases.Billing.GetById;
using BarberBoss.Application.UseCases.Billing.Register;
using BarberBoss.Application.UseCases.Billing.Update;
using BarberBoss.Communication.Filter;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using BarberBoss.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BarberBoss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(BillingResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostBilling([FromServices] IRegisterBillingUseCase registerBillingUseCase, [FromBody] BillingRequest request)
        {
            var response = await registerBillingUseCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ListBillingsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllBilling([FromServices] IGetAllBillingsUseCase getAllBillingUseCase)
        {
            var result = await getAllBillingUseCase.Execute();

            if (result.Billings.Count > 0 && result is not null)
                return Ok(result);

            return NoContent();

        }

        [HttpGet("filters")]
        [ProducesResponseType(typeof(PagedResultResponse<BillingResponse?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllBillingWithFilters([FromServices] IGetAllWithFiltersUseCase getAllWithFilters, [FromQuery] FilterRequest filter)
        {
            var result = await getAllWithFilters.Execute(filter);

            if (result.Items.Count > 0 && result is not null)
                return Ok(result);

            return NoContent();

        }



        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BillingResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundException), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdBilling([FromServices] IGetByIdBillingUseCase getByIdBillingUseCase,
                                                        [FromRoute][Required] Guid id)
        {

            var result = await getByIdBillingUseCase.Execute(id);

            return Ok(result);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBilling([FromServices] IUpdateBillingUseCase updateBillingUseCase,
                                                       [FromRoute] Guid id, [FromBody] BillingRequest request)
        {
            await updateBillingUseCase.Execute(id, request);
            return NoContent();

        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(NotFoundException), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteBilling([FromServices] IDeleteBillingUseCase deleteBillingUseCase,
                                                       [FromRoute] Guid id)
        {
            await deleteBillingUseCase.Execute(id);

            return NoContent();
        }



    }
}
