using DesingPatterns.Application.TemplateMethod.Model;
using DesingPatterns.Domain.TemplateMethod.DescontoCondicional;

namespace DesingPatterns.Application.TemplateMethod.Calculador
{
    public abstract class TemplateImpostoCondicional : IImpostoCondicional
    {
        public async Task<ImpostoCondicionalEntity> Calcular(ImpostoCondicionalRequest request, ImpostoCondicionalEntity entitty)
        {
            if (DeveUsarMaximaTaxacao(request, entitty))
            {
                entitty.TaxacaoMaxima = await MaximaTaxacao(request, entitty);
                return entitty;            
            }
            else 
            {
                entitty.TaxacaoMinima = await MinimaTaxacao(request, entitty);
                return entitty;
            }
        }

        public abstract bool DeveUsarMaximaTaxacao(ImpostoCondicionalRequest request, ImpostoCondicionalEntity impostoEntitty);
        public abstract Task<decimal> MaximaTaxacao(ImpostoCondicionalRequest request, ImpostoCondicionalEntity impostoEntitty);
        public abstract Task<decimal> MinimaTaxacao(ImpostoCondicionalRequest request, ImpostoCondicionalEntity impostoEntitty);
    }
}
