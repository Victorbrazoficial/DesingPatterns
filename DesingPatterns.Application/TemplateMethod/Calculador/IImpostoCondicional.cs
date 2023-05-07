using DesingPatterns.Application.TemplateMethod.Model;
using DesingPatterns.Domain.TemplateMethod.DescontoCondicional;

namespace DesingPatterns.Application.TemplateMethod.Calculador
{
    public interface IImpostoCondicional
    {
        Task<ImpostoCondicionalEntity> Calcular(ImpostoCondicionalRequest request, ImpostoCondicionalEntity impostoEntitty);
    }
}
