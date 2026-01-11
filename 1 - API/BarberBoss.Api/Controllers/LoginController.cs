using BarberBoss.Application.UseCases.User.DoLogin;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUser),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Login([FromServices] IDoLoginUseCase useCase, [FromBody] RequestLogin request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

    }
}
