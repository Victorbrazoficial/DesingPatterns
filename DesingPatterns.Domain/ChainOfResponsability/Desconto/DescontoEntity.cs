namespace DesingPatterns.Domain.ChainOfResponsability.Desconto
{
    public class DescontoEntity : IDescontoEntity
    {
        public string Texto { get; set; }
        public decimal Valor { get; set; }
        public decimal TaxaDescotno { get; set; }
        public List<Item>? Itens { get; set; }
    }

    public class Item
    {
        public string? Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
