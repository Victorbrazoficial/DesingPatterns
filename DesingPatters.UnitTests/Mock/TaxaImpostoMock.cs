using DesingPatterns.Domain.Strategy.Imposto;

namespace DesingPatters.UnitTests.Mock
{
    public abstract class TaxaImpostoMock
    {
        public static async Task<CalculadorDeImposto> ICMS()
        {
            return new CalculadorDeImposto()
            {
                TaxaImposto = 12m
            };
        }

        public static async Task<CalculadorDeImposto> ISS()
        {
            return new CalculadorDeImposto()
            {
                TaxaImposto = 2M
            };
        }
    }
}
