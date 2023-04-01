using DesingPatterns.Application.Strategy.Model.Imposto.ICMS;
using DesingPatterns.Domain.Strategy.Imposto;

namespace DesingPatterns.Application.Strategy.Calculador.Interface
{
    public interface IImposto
    {
        Task<CalculadorDeImposto> Calcular(ObterICMSRequest request);
    }
}
