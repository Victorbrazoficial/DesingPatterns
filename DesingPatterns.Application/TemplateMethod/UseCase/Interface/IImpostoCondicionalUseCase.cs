using DesingPatterns.Application.TemplateMethod.Model;

namespace DesingPatterns.Application.TemplateMethod.UseCase.Interface
{
    public interface IImpostoCondicionalUseCase
    {
        Task<ImpostoCondicionalResponse> Execute(ImpostoCondicionalRequest request);
    }
}
