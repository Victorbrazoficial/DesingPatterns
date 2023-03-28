using DesingPatterns.Application.Strategy.Repositories;
using DesingPatterns.Domain.Strategy.Imposto;

namespace DesingPatterns.Infrastructure.Strategy.Repositories.Imposto
{
    public class TaxaImpostoRepository : ITaxaImpostoRepository
    {
        private const decimal TaxaICMS = 12M;
        public async Task<CalculadorDeImposto> GetICMS()
        {
            var response = new CalculadorDeImposto()
                {
                    TaxaImposto = TaxaICMS
                };
            return  response;
        }
    }
}
