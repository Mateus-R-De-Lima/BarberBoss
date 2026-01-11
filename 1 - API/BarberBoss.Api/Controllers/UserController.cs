using BarberBoss.Application.UseCases.User.Delete;
using BarberBoss.Application.UseCases.User.GetProfile;
using BarberBoss.Application.UseCases.User.Register;
using BarberBoss.Application.UseCases.User.UpdateProfile;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using Microsoft.AspNetCore.Authorization;
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


        [HttpGet("profile")]
        [ProducesResponseType(typeof(ResponseUserProfile),StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> GetProfile([FromServices] IGetUserProfileUseCase useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }


        [HttpPut("profile")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseError),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutProfile([FromServices] IUpdateUserProfileUseCase useCase,
                                                    [FromBody] RequestUpdateProfile request)
        {
            await useCase.Execute(request);
            return NoContent();
        }

        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromServices] IDeleteProfileUserUseCase useCase)
        {
            await useCase.Execute();
            return NoContent();
        }

      

    }
}
