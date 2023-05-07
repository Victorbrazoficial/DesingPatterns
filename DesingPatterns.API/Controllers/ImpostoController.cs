using DesingPatterns.Application.Strategy.Model.Imposto.ICMS;
using DesingPatterns.Application.Strategy.UseCase.Imposto.Interface;
using DesingPatterns.Application.TemplateMethod.Model;
using DesingPatterns.Application.TemplateMethod.UseCase.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DesingPatterns.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ImpostoController : ControllerBase
    {
        [HttpGet]
        [Route("imposto")]
        public async Task<IActionResult> GetICMS([FromBody] ObterImpostoDeduzidoRequest request, [FromServices] IObterImpostoDeduzidoUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("impostoCondicional")]
        public async Task<IActionResult> GetICPP([FromBody] ImpostoCondicionalRequest request, [FromServices] IImpostoCondicionalUseCase useCase)
        {
            var response = await useCase.Execute(request);

            if (response is null)
                return BadRequest("Imposto inserido não existe");

            return Ok(response);

        }
    }
}
