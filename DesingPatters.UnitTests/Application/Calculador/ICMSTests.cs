using DesingPatterns.Application.Strategy.Calculador;
using DesingPatterns.Application.Strategy.Model.Imposto.ICMS;
using DesingPatterns.Application.Strategy.Repositories;
using DesingPatters.UnitTests.Mock;
using FluentAssertions;
using Moq;

namespace DesingPatters.UnitTests.Application.Calculador
{
    public class ICMSTests
    {
        private readonly Mock<ITaxaImpostoRepository> _repositoryMock;

        public ICMSTests()
        {
            _repositoryMock = new Mock<ITaxaImpostoRepository>();
        }

        [Fact]
        public async void Icms_sucesso()
        {
            var request = new ObterImpostoDeduzidoRequest()
            {
                imposto = "icms",
                Valor = 1000
            };

            _repositoryMock.Setup(x => x.GetICMS()).Returns(TaxaImpostoMock.ICMS);

            var icms = new ICMS(_repositoryMock.Object);

            var result = await icms.Calcular(request);

            result.Should().NotBeNull();
            result.ValorComImpostoDeduzido.Should().Be(880);
        }

    }
}
