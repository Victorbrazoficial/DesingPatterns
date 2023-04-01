using DesingPatterns.Application.Strategy.Calculador.Interface;
using DesingPatterns.Application.Strategy.Model.Imposto.ICMS;
using DesingPatterns.Application.Strategy.Repositories;
using DesingPatterns.Domain.Strategy.Imposto;

namespace DesingPatterns.Application.Strategy.Calculador
{
    public class ICMS : IImposto
    {
        private readonly ITaxaImpostoRepository _taxaImpostoRepository;

        public ICMS(ITaxaImpostoRepository taxaImpostoRepository)
        {
            _taxaImpostoRepository = taxaImpostoRepository;
        }

        public async Task<CalculadorDeImposto> Calcular(ObterICMSRequest request)
        {
            var icms =  await _taxaImpostoRepository.GetICMS();

            var resultado = request.Valor - (request.Valor * icms.TaxaImposto / 100);

            var response = new CalculadorDeImposto()
            {
                ValorComImpostoDeduzido = resultado,
                NomeImposto = request.imposto,
                TaxaImposto = icms.TaxaImposto
            };

            return response;
        }
    }
}
