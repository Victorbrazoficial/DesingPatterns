using DesingPatterns.Application.Decorator.Impostos.Decorator.Interfaces;

namespace DesingPatterns.Application.Decorator.Impostos
{
    public class ImpostoBase : IImpostoBase
    {
        public decimal SomaImposto()
        {
            return 0;
        }
    }
}
