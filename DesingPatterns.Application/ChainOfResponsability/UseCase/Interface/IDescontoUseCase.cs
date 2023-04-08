using DesingPatterns.Application.ChainOfResponsability.Model;

namespace DesingPatterns.Application.ChainOfResponsability.UseCase.Interface
{
    public interface IDescontoUseCase
    {
        Task<DescontoResponse> Execute(DescontoRequest request);
    }
}
