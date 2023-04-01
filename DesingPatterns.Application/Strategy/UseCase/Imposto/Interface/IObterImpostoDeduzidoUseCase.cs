using DesingPatterns.Application.Strategy.Model.Imposto.ICMS;

namespace DesingPatterns.Application.Strategy.UseCase.Imposto.Interface
{
    public interface IObterImpostoDeduzidoUseCase
    {
        Task<ObterImpostoDeduzidoResponse> Execute(ObterImpostoDeduzidoRequest request);
    }
}
