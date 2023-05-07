namespace DesingPatterns.Domain.TemplateMethod.DescontoCondicional
{
    public class ImpostoCondicionalEntity
    {
        public decimal TaxacaoMaxima { get; set; }
        public decimal TaxacaoMinima { get; set; }
        public decimal TaxaImpostoUltilizado { get; set; }
        public decimal Valor { get; set; }
        public string NomeImposto { get; set; }
    }
}
