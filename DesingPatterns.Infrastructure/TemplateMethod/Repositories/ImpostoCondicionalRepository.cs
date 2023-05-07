using DesingPatterns.Application.TemplateMethod.Model;
using DesingPatterns.Application.TemplateMethod.Repositories;
using DesingPatterns.Domain.TemplateMethod.DescontoCondicional;

namespace DesingPatterns.Infrastructure.TemplateMethod.Repositories
{
    public class ImpostoCondicionalRepository : IImpostoCondicionalRepository
    {
        public const decimal TaxaMaximaICPP = 0.07m;
        public const decimal TaxaMinimaICPP = 0.05m;
        public const decimal TaxaMaximaIKCV = 0.10m;
        public const decimal TaxaMinimaIKCV = 0.06m;

        public async Task<ImpostoCondicionalEntity> GetImpostoCondicional(ImpostoCondicionalRequest request)
        {
            switch (request.Imposto)
            {
                case ConstanteImpostoCondicional.ICPP:
                    return new ImpostoCondicionalEntity()
                    {
                        TaxacaoMaxima = TaxaMaximaICPP,
                        TaxacaoMinima = TaxaMinimaICPP,
                        NomeImposto = ConstanteImpostoCondicional.ICPP
                    };

                    case ConstanteImpostoCondicional.IKCV:
                    return new ImpostoCondicionalEntity()
                    {
                        TaxacaoMaxima = TaxaMaximaIKCV,
                        TaxacaoMinima = TaxaMinimaIKCV,
                        NomeImposto = ConstanteImpostoCondicional.IKCV
                    };
            }

            return null;
        }
    }
}
