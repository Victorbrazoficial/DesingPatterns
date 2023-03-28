using DesingPatterns.Application.Strategy.Model.Imposto.ICMS;
using DesingPatterns.Domain.Strategy.Imposto;

namespace DesingPatterns.Application.Strategy.Calculador.Interface
{
    public interface ICalculador
    {
        Task<CalculadorDeImposto> IdentificaImposto(ObterICMSRequest request);
    }
}