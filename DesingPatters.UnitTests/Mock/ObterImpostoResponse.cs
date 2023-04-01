using DesingPatterns.Domain.Strategy.Imposto;

namespace DesingPatters.UnitTests.Mock
{
    public abstract class ObterImpostoResponse
    {
        public static async Task<CalculadorDeImposto> CalculadorDeImpostoReponse()
        {
            return new CalculadorDeImposto()
            {
                NomeImposto = "icms",
                TaxaImposto = 12m,
                ValorComImpostoDeduzido = 880m
            };
        }
    }
}
