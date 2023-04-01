using DesingPatterns.Application.Strategy.Calculador.Interface;
using DesingPatterns.Application.Strategy.Model.Imposto.ICMS;
using DesingPatterns.Application.Strategy.Repositories;
using DesingPatterns.Domain.Strategy.Enum;
using DesingPatterns.Domain.Strategy.Imposto;
using Moq;

namespace DesingPatters.UnitTests.Mock
{
    public abstract class CalculadorMock
    {
        public static CalculadorDeImposto ObterTipoImposto(ObterImpostoDeduzidoRequest request, Mock<ITaxaImpostoRepository> repositoryMock = null)
        {
            if (repositoryMock is null)
            {
                repositoryMock = new Mock<ITaxaImpostoRepository>();
            }

            IImposto imposto;
            switch (request.imposto)
            {
                case ImpostoTipo.Icms:
                    repositoryMock.Setup(x => x.GetICMS()).Returns(Icms());
                    break;

                case ImpostoTipo.Iss:
                    repositoryMock.Setup(x => x.GetICMS()).Returns(Iss());
                    break;
            }

            return null;
        }

        public static async Task<CalculadorDeImposto> Icms()
        {
            var response = new CalculadorDeImposto()
            {
                NomeImposto = "icms",
                TaxaImposto = 12m,
                ValorComImpostoDeduzido = 880M
            };

            return response;
        }

        public static async Task<CalculadorDeImposto> Iss()
        {
            var response = new CalculadorDeImposto()
            {
                NomeImposto = "iss",
                TaxaImposto = 12m,
                ValorComImpostoDeduzido = 980M
            };

            return response;
        }
    }
}
