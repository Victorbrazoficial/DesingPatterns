using DesingPatterns.Application.ChainOfResponsability.Model;
using DesingPatterns.Domain.ChainOfResponsability.Desconto;

namespace DesingPatterns.Application.ChainOfResponsability.Repositories
{
    public interface ITaxaDescontoRepository
    {
        Task<DescontoEntity> GetDescontoPorCincoItens(DescontoRequest request);
    }
}
