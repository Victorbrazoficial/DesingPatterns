using DesingPatterns.Domain.Strategy.Imposto;

namespace DesingPatterns.Application.Strategy.Repositories
{
    public interface ITaxaImpostoRepository
    {
        Task<CalculadorDeImposto> GetICMS();
        Task<CalculadorDeImposto> GetISS();
    }
}
