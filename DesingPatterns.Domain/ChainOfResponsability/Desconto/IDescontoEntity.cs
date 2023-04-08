namespace DesingPatterns.Domain.ChainOfResponsability.Desconto
{
    public interface IDescontoEntity
    {
        public decimal Valor { get; set; }
        public decimal TaxaDescotno { get; set; }
        public List<Item>? Itens { get; set; }
    }
}
