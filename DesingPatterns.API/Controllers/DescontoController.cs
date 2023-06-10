using DesingPatterns.Application.ChainOfResponsability.Model;
using DesingPatterns.Application.ChainOfResponsability.UseCase.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DesingPatterns.API.Controllers
{
    [Route("api/desconto/")]
    [ApiController]
    public class DescontoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetDesconto([FromBody] DescontoRequest request, [FromServices] IDescontoUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
