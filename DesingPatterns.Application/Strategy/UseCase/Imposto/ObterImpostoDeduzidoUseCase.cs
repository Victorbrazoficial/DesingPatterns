using DesingPatterns.Application.Strategy.Calculador.Interface;
using DesingPatterns.Application.Strategy.Model.Imposto.ICMS;
using DesingPatterns.Application.Strategy.UseCase.Imposto.Interface;

namespace DesingPatterns.Application.Strategy.UseCase.Imposto
{
    public class ObterImpostoDeduzidoUseCase : IObterImpostoDeduzidoUseCase
    {
        private readonly ICalculador? _iCalculador;

        public ObterImpostoDeduzidoUseCase(ICalculador iCalculador)
        {
            _iCalculador = iCalculador;
        }

        public async Task<ObterImpostoDeduzidoResponse> Execute(ObterImpostoDeduzidoRequest request)
        {

            var impostoCalculado = await _iCalculador.IdentificaImposto(request);

            var response = new ObterImpostoDeduzidoResponse()
            {
                NomeImposto = impostoCalculado.NomeImposto,
                ValorComImpostoDeduzido = impostoCalculado.ValorComImpostoDeduzido,
                taxaImposto = impostoCalculado.TaxaImposto
            };

            return  response;
        }
    }
}
