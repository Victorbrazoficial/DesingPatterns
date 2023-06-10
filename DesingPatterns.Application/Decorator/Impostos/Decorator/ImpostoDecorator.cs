using DesingPatterns.Application.Decorator.Impostos.Decorator.Interfaces;

namespace DesingPatterns.Application.Decorator.Impostos.Decorator
{
    public class ImpostoDecorator : IImpostoBase
    {
        private readonly IImpostoBase _impostoBase;
        public decimal TaxaImposto { get; set; }

        public ImpostoDecorator(IImpostoBase impostoBase)
        {
            _impostoBase = impostoBase;
        }
        public ImpostoDecorator()
        {
            _impostoBase = null;
        }

        public virtual decimal SomaImposto()
        {
            return _impostoBase.SomaImposto();
        }
    }
}
