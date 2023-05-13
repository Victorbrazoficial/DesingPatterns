using DesingPatterns.Application.ChainOfResponsability.Model;

namespace DesingPatterns.Application.TemplateMethod.Model
{
    public class ImpostoCondicionalRequest
    {
        public string Imposto { get; set; }
        public List<ItemImpostoCondicional> Itens { get; set; }
    }

    public class ItemImpostoCondicional
    {
        public decimal ValorProduto { get; set; }
        public string? NomeProduto { get; set; }
    }
}
