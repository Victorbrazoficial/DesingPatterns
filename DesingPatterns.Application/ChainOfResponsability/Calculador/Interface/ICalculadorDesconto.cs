using DesingPatterns.Application.ChainOfResponsability.Model;
using DesingPatterns.Domain.ChainOfResponsability.Desconto;

namespace DesingPatterns.Application.ChainOfResponsability.Calculador.Interface
{
    public interface ICalculadorDescontos
    {
        Task<DescontoEntity> Desconta(DescontoRequest request);
    }
}
