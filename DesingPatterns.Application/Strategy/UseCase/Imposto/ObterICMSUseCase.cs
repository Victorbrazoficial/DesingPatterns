using DesingPatterns.Application.Strategy.Calculador.Interface;
using DesingPatterns.Application.Strategy.Model.Imposto.ICMS;
using DesingPatterns.Application.Strategy.UseCase.Imposto.Interface;

namespace DesingPatterns.Application.Strategy.UseCase.Imposto
{
    public class ObterICMSUseCase : IObterICMSUseCase
    {
        private readonly ICalculador? _iCalculador;

        public ObterICMSUseCase(ICalculador iCalculador)
        {
            _iCalculador = iCalculador;
        }

        public async Task<ObterICMSResponse> Execute(ObterICMSRequest request)
        {

            var impostoCalculado = await _iCalculador.IdentificaImposto(request);

            var response = new ObterICMSResponse()
            {
                NomeImposto = impostoCalculado.NomeImposto,
                ValorComImpostoDeduzido = impostoCalculado.ValorComImpostoDeduzido,
                taxaImposto = impostoCalculado.TaxaImposto
            };

            return  response;
        }
    }
}
