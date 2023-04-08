using DesingPatterns.Application.Strategy.Model.Imposto.ICMS;
using DesingPatterns.Application.Strategy.UseCase.Imposto.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DesingPatterns.API.Controllers
{
    [Route("api/imposto/")]
    [ApiController]
    public class ImpostoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetICMS([FromBody] ObterImpostoDeduzidoRequest request, [FromServices] IObterImpostoDeduzidoUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
