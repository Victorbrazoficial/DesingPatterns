using DesingPatterns.Application.Strategy.Calculador.Interface;
using DesingPatterns.Application.Strategy.Model.Imposto.ICMS;
using DesingPatterns.Application.Strategy.UseCase.Imposto;
using DesingPatterns.Application.Strategy.UseCase.Imposto.Interface;
using DesingPatters.UnitTests.Mock;
using FluentAssertions;
using Moq;

namespace DesingPatters.UnitTests.Application.UseCase
{
    public class ObterImpostoUseCaseTests
    {
        private readonly Mock<ICalculador> _calculador;
        private readonly IObterImpostoDeduzidoUseCase _useCase;

        public ObterImpostoUseCaseTests()
        {
            _calculador = new Mock<ICalculador>();
            _useCase = new ObterImpostoDeduzidoUseCase(_calculador.Object);
        }

        [Fact]
        public async void Execute_Sucesso()
        {
            var request = new ObterImpostoDeduzidoRequest()
            {
                imposto = "icms",
                Valor = 1000
            };

            var response = ObterImpostoResponseMock.CalculadorDeImpostoReponse();

            var teste = _calculador.Setup(x => x.IdentificaImposto(It.IsAny<ObterImpostoDeduzidoRequest>())).Returns(response);

            var result = await _useCase.Execute(request);

            result.Should().NotBeNull();
            result.NomeImposto.Should().Be("icms");
            result.taxaImposto.Should().Be(12M);
            result.ValorComImpostoDeduzido.Should().Be(880m);
        }
    }
}
