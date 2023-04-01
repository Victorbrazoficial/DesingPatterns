using DesingPatterns.Application.Strategy.Repositories;
using DesingPatterns.Domain.Strategy.Imposto;

namespace DesingPatterns.Infrastructure.Strategy.Repositories.Imposto
{
    public class TaxaImpostoRepository : ITaxaImpostoRepository
    {
        private const decimal TaxaICMS = 12M;
        private const decimal TaxaISS = 2M;
        public async Task<CalculadorDeImposto> GetICMS()
        {
            var response = new CalculadorDeImposto()
                {
                    TaxaImposto = TaxaICMS
                };
            return  response;
        }

        public async Task<CalculadorDeImposto> GetISS()
        {
            var response = new CalculadorDeImposto()
            {
                TaxaImposto = TaxaISS
            };

            return response;
        }        
    }
}
