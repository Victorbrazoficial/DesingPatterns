using DesingPatterns.Application.Decorator.Impostos.Decorator.Interfaces;

namespace DesingPatterns.Application.Decorator.Impostos.Decorator
{
    public class IssDecorator : ImpostoDecorator
    {
        public IssDecorator(IImpostoBase impostoDecorator) : base(impostoDecorator)
        { }

        public override decimal SomaImposto(decimal taxaImposto)
        {
            var result = base.SomaImposto(taxaImposto);
            result += 2; 
            return result;
        }
    }
}
