using DesingPatterns.Application.ChainOfResponsability.Calculador.Interface;
using DesingPatterns.Application.ChainOfResponsability.Model;
using DesingPatterns.Application.ChainOfResponsability.UseCase;
using DesingPatters.UnitTests.Mock;
using FluentAssertions;
using Moq;

namespace DesingPatters.UnitTests.Application.UseCase
{
    public class DescontoUseCaseTests
    {
        private readonly Mock<ICalculadorDescontos> _calculador;
        private readonly DescontoUseCase _useCase;

        public DescontoUseCaseTests()
        {
            _calculador = new Mock<ICalculadorDescontos>();
            _useCase = new DescontoUseCase(_calculador.Object);
        }

        [Fact]
        public async void ExecuteComDesconto_Sucesso()
        {
            var request = new DescontoRequest()
            {
                Itens = new List<Item>()
                {
                    new Item()
                    {
                        NomeProduto = "nome produto1",
                        ValorProduto = 5.50m
                    },
                    new Item()
                    {
                        NomeProduto = "nome produto2",
                        ValorProduto = 5.50m
                    },
                    new Item()
                    {
                        NomeProduto = "nome produto3",
                        ValorProduto = 5.50m
                    },
                    new Item()
                    {
                        NomeProduto = "nome produto4",
                        ValorProduto = 5.50m
                    },
                    new Item()
                    {
                        NomeProduto = "nome produto5",
                        ValorProduto = 5.50m
                    },
                    new Item()
                    {
                        NomeProduto = "nome produto6",
                        ValorProduto = 5.50m
                    }
                }
            };

            var response = DescontoMock.DescontoResponse(request);

            var teste = _calculador.Setup(x => x.Desconta(request)).Returns(response);

            var result = await _useCase.Execute(request);

            result.Should().NotBeNull();
            result.Texto = "Você atingiu mais de cinco itens por isso recebeu um desconto de 0.1% em relção ao valor total.";
            result.ValorDesconto.Should().Be(3.30m);
        }

        [Fact]
        public async void ExecuteSemDesconto_Sucesso()
        {
            var request = new DescontoRequest()
            {
                Itens = new List<Item>()
                {
                    new Item()
                    {
                        NomeProduto = "nome produto1",
                        ValorProduto = 5.50m
                    },
                    new Item()
                    {
                        NomeProduto = "nome produto2",
                        ValorProduto = 5.50m
                    },
                    new Item()
                    {
                        NomeProduto = "nome produto3",
                        ValorProduto = 5.50m
                    },
                    new Item()
                    {
                        NomeProduto = "nome produto4",
                        ValorProduto = 5.50m
                    }
                }
            };

            var response = DescontoMock.SemDescontoResponse();

            var teste = _calculador.Setup(x => x.Desconta(request)).Returns(response);

            var result = await _useCase.Execute(request);

            result.Should().NotBeNull();
            result.Texto = "Se você atingir a quantidade de seis itens você recebera um desconto.";
            result.ValorDesconto.Should().Be(0.0m);
        }
    }
}
