using DesingPatterns.Application.Strategy.Calculador.Interface;
using DesingPatterns.Application.Strategy.Model.Imposto.ICMS;
using DesingPatterns.Application.Strategy.Repositories;
using DesingPatterns.Domain.Strategy.Imposto;

namespace DesingPatterns.Application.Strategy.Calculador
{
    public class ISS : IImposto
    {
        private readonly ITaxaImpostoRepository _taxaImpostoRepository;

        public ISS(ITaxaImpostoRepository taxaImpostoRepository)
        {
            _taxaImpostoRepository = taxaImpostoRepository;
        }

        public async Task<CalculadorDeImposto> Calcular(ObterICMSRequest request)
        {
            var iss = await _taxaImpostoRepository.GetISS();

            var resultado = request.Valor - (request.Valor * iss.TaxaImposto / 100);

            var response = new CalculadorDeImposto()
            {
                NomeImposto = request.imposto,
                TaxaImposto = iss.TaxaImposto,
                ValorComImpostoDeduzido = resultado
            };

            return response;
        }
    }
}
