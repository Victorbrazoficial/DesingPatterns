using DesingPatterns.Application.Decorator.Impostos.Decorator.Interfaces;

namespace DesingPatterns.Application.Decorator.Impostos.Decorator
{
    public class ImpostoDecorator : IImpostoBase
    {
        private readonly IImpostoBase _impostoBase;

        public ImpostoDecorator(IImpostoBase impostoBase)
        {
            _impostoBase = impostoBase;
        }
        public ImpostoDecorator()
        {
            _impostoBase = null;
        }

        public virtual decimal SomaImposto(decimal taxaImposto)
        {
            return _impostoBase.SomaImposto(taxaImposto);
        }
    }
}
