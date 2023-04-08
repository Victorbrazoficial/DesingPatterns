using DesingPatterns.Application.ChainOfResponsability.Calculador.Interface;
using DesingPatterns.Application.ChainOfResponsability.Model;
using DesingPatterns.Application.ChainOfResponsability.UseCase.Interface;

namespace DesingPatterns.Application.ChainOfResponsability.UseCase
{
    public class DescontoUseCase : IDescontoUseCase
    {
        private readonly ICalculadorDescontos _calculadorDescontos;

        public DescontoUseCase(ICalculadorDescontos calculadorDescontos)
        {
            _calculadorDescontos = calculadorDescontos;
        }

        public async Task<DescontoResponse> Execute(DescontoRequest request)
        {
            var desconto = await _calculadorDescontos.Desconta(request);

            var response = new DescontoResponse()
            {
                Texto = desconto.Texto,
                ValorDesconto = desconto.Valor
            };

            return response;
        }
    }
}
