using DesingPatterns.Application.Decorator.Impostos.Decorator.Interfaces;

namespace DesingPatterns.Application.Decorator.Impostos.Decorator
{
    public class IcmsDecorator : ImpostoDecorator
    {
        public IcmsDecorator(IImpostoBase impostoDecorator) : base(impostoDecorator)
        { }

        public override decimal SomaImposto()
        {
            var result = base.SomaImposto();
            result += TaxaImposto;
            return result;
        }
    }
}
