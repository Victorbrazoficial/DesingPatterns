using DesingPatterns.Application.Decorator.Impostos.Decorator.Interfaces;

namespace DesingPatterns.Application.Decorator.Impostos.Decorator
{
    public class IssDecorator : ImpostoDecorator
    {
        public IssDecorator(IImpostoBase impostoDecorator) : base(impostoDecorator)
        { }

        public override decimal SomaImposto()
        {
            var result = base.SomaImposto();
            result += TaxaImposto; 
            return result;
        }
    }
}
