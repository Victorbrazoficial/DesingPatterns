namespace DesingPatterns.Domain.Decorator.Imposto
{
    public class ImpostoDecoratorEntity
    {
        public string? NomeImposto { get; set; }
        public decimal TaxaImposto { get; set; }
        public decimal ImpostoDeduzido { get; set; }
    }
}
