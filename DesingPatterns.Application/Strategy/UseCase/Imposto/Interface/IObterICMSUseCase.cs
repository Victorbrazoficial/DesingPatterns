using DesingPatterns.Application.Strategy.Model.Imposto.ICMS;

namespace DesingPatterns.Application.Strategy.UseCase.Imposto.Interface
{
    public interface IObterICMSUseCase
    {
        Task<ObterICMSResponse> Execute(ObterICMSRequest request);
    }
}
