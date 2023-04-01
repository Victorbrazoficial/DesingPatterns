using DesingPatterns.Application.Strategy.Calculador;
using DesingPatterns.Application.Strategy.Model.Imposto.ICMS;
using DesingPatterns.Application.Strategy.Repositories;
using DesingPatters.UnitTests.Mock;
using FluentAssertions;
using Moq;

namespace DesingPatters.UnitTests.Application.Calculador
{
    public class ISSTests
    {
        private readonly Mock<ITaxaImpostoRepository> _repositoryMock;

        public ISSTests()
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

            _repositoryMock.Setup(x => x.GetISS()).Returns(TaxaImpostoMock.ISS);

            var iss = new ISS(_repositoryMock.Object);

            var result = await iss.Calcular(request);

            result.Should().NotBeNull();
            result.ValorComImpostoDeduzido.Should().Be(980);
        }
    }
}
