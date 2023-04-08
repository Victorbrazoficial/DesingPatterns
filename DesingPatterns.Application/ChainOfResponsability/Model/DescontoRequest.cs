using DesingPatterns.Domain.ChainOfResponsability.Desconto;

namespace DesingPatterns.Application.ChainOfResponsability.Model
{
    public class DescontoRequest
    {
        public List<Item> Itens { get; set; }
    }

    public class Item
    {
        public decimal ValorProduto { get; set; }
        public string? NomeProduto { get; set; }
    }
}
