using DesingPatterns.Application.TemplateMethod.Model;
using DesingPatterns.Domain.TemplateMethod.DescontoCondicional;

namespace DesingPatterns.Application.TemplateMethod.Repositories
{
    public interface IImpostoCondicionalRepository
    {
        Task<ImpostoCondicionalEntity> GetImpostoCondicional(ImpostoCondicionalRequest request);
    }
}
