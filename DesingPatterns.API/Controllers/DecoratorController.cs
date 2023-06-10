using DesingPatterns.Application.Decorator.Model.Imposto;
using DesingPatterns.Application.Decorator.UseCase.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DesingPatterns.API.Controllers
{
    [Route("api/decorator")]
    [ApiController]
    public class DecoratorController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetDesconto([FromBody] DecoratorRequest request, [FromServices] IDecoratorUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
