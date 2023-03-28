namespace DesingPatterns.Domain.Strategy.Imposto
{
    public class CalculadorDeImposto : ICalculadorDeImposto
    {
        public decimal ValorComImpostoDeduzido { get; set;}
        public decimal TaxaImposto { get; set; }
        public string? NomeImposto { get; set; }
    }
}
