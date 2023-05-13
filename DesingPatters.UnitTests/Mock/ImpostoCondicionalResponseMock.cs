using DesingPatterns.Domain.TemplateMethod.DescontoCondicional;

namespace DesingPatters.UnitTests.Mock
{
    public static class ImpostoCondicionalResponseMock
    {
        public const decimal TaxaMaximaICPP = 0.07m;
        public const decimal TaxaMinimaICPP = 0.05m;
        public const decimal TaxaMaximaIKCV = 0.10m;
        public const decimal TaxaMinimaIKCV = 0.06m;

        public static async Task<ImpostoCondicionalEntity> ResponseMock(string imposto)
        {

            if (imposto.Equals("ikcv"))
            {
                return  new ImpostoCondicionalEntity()
                {
                    NomeImposto = "ikcv",
                    TaxacaoMaxima = TaxaMaximaIKCV,
                    TaxacaoMinima = TaxaMinimaIKCV,
                };
            }
            else
            {
                return new ImpostoCondicionalEntity()
                {
                    NomeImposto = "icpp",
                    TaxacaoMaxima = TaxaMaximaICPP,
                    TaxacaoMinima = TaxaMinimaICPP,
                };
            }
        }
    }
}
