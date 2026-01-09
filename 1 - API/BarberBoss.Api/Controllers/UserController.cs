using BarberBoss.Application.UseCases.User.Register;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUser),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError),StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Register(
            [FromServices] IRegisterUserUseCase useCase,
            [FromBody] RequestUser request
            )
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
