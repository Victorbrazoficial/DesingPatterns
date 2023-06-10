using DesingPatterns.Application.Decorator.Model.Imposto;
using DesingPatterns.Domain.Decorator.Imposto;

namespace DesingPatterns.Application.Decorator.Repositories
{
    public interface IDecoratorRepository
    {
        List<ImpostoDecoratorEntity> GetTaxaImposto(DecoratorRequest request);
    }
}
