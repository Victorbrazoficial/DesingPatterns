using DesingPatterns.Application.TemplateMethod.Model;
using DesingPatterns.Domain.TemplateMethod.DescontoCondicional;

namespace DesingPatterns.Application.TemplateMethod.Calculador
{
    public class ICPP : TemplateImpostoCondicional
    {
        public override bool DeveUsarMaximaTaxacao(ImpostoCondicionalRequest request, ImpostoCondicionalEntity entitty)
        {
            return SomaValorItens(request) >= 500;
        }

        public async override Task<decimal> MinimaTaxacao(ImpostoCondicionalRequest request, ImpostoCondicionalEntity entitty)
        {
            var taxa = entitty.TaxacaoMinima;
            var valoTotal = SomaValorItens(request);
            var valorImposto = valoTotal * taxa;

            MapeandoDados(valoTotal, valorImposto, taxa, entitty);

            return valorImposto;
        }

        public async override Task<decimal> MaximaTaxacao(ImpostoCondicionalRequest request, ImpostoCondicionalEntity entitty)
        {
            var taxa = entitty.TaxacaoMaxima;
            var valorTotal = SomaValorItens(request);
            var valorImposto = valorTotal * taxa;

            MapeandoDados(valorTotal, valorImposto, taxa, entitty);

            return valorImposto;
        }

        private void MapeandoDados(decimal valorTotal, decimal valorImposto, decimal taxa, ImpostoCondicionalEntity entitty)
        {
            entitty.TaxaImpostoUltilizado = taxa;
            entitty.Valor = valorTotal;
            entitty.Valor = valorTotal - valorImposto;
        }

        private decimal SomaValorItens(ImpostoCondicionalRequest request)
        {
            var response = new ImpostoCondicionalEntity();

            foreach (var item in request.Itens)
            {
                response.Valor += item.ValorProduto;
            }

            return response.Valor;
        }
    }
}
