using DesingPatterns.Application.Decorator.Impostos.Decorator.Interfaces;

namespace DesingPatterns.Application.Decorator.Impostos.Decorator
{
    public class IcmsDecorator : ImpostoDecorator
    {
        public IcmsDecorator(IImpostoBase impostoDecorator) : base(impostoDecorator)
        { }

        public override decimal SomaImposto(decimal taxaImposto)
        {
            var result = base.SomaImposto(taxaImposto);
            result += 12;
            return result;
        }
    }
}
