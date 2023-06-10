using DesingPatterns.Application.Decorator.Model.Imposto;

namespace DesingPatterns.Application.Decorator.UseCase.Interface
{
    public interface IDecoratorUseCase
    {
        Task<DecoratorResponse> Execute(DecoratorRequest request);
    }
}
