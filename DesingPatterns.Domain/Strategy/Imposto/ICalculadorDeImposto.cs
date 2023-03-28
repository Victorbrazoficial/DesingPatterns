namespace DesingPatterns.Domain.Strategy.Imposto
{
    public interface ICalculadorDeImposto
    {
        public decimal ValorComImpostoDeduzido { get; set; }
        public decimal TaxaImposto { get; set; }
    }
}
