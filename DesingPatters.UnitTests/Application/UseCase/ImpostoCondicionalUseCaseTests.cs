using DesingPatterns.Application.TemplateMethod.Model;
using DesingPatterns.Application.TemplateMethod.Repositories;
using DesingPatterns.Application.TemplateMethod.UseCase;
using DesingPatters.UnitTests.Mock;
using FluentAssertions;
using Moq;

namespace DesingPatters.UnitTests.Application.UseCase
{
    public class ImpostoCondicionalUseCaseTests
    {
        private readonly Mock<IImpostoCondicionalRepository> _repository;
        private readonly ImpostoCondicionalUseCase _useCase;

        public ImpostoCondicionalUseCaseTests()
        {
            _repository = new Mock<IImpostoCondicionalRepository>();
            _useCase = new ImpostoCondicionalUseCase(_repository.Object);
        }

        [Fact]
        public async void ExecuteIkcv_ValorMaiorQue500_ImpostoMaximo_Sucesso()
        {
            var request = new ImpostoCondicionalRequest()
            {
                Imposto = "ikcv",
                Itens = new List<ItemImpostoCondicional>
                {
                    new ItemImpostoCondicional()
                    {
                        NomeProduto = "xyz",
                        ValorProduto = 250m
                    },
                    new ItemImpostoCondicional()
                    {
                        NomeProduto = "xyz",
                        ValorProduto = 250m
                    }
                }
            };

            var response = ImpostoCondicionalResponseMock.ResponseMock("ikcv");

            _repository.Setup(x => x.GetImpostoCondicional(request)).Returns(response);

            var result = await _useCase.Execute(request);

            result.Should().NotBeNull();
            result.NomeImposto.Should().Be("ikcv");
            result.TaxaImposto.Should().Be(0.10m);
            result.ValorComImpostoDeduzido.Should().Be(450m);
        }

        [Fact]
        public async void ExecuteIkcv_ValorMenorQue500_ImpostoMinimo_Sucesso()
        {
            var request = new ImpostoCondicionalRequest()
            {
                Imposto = "ikcv",
                Itens = new List<ItemImpostoCondicional>
                {
                    new ItemImpostoCondicional()
                    {
                        NomeProduto = "xyz",
                        ValorProduto = 250m
                    }
                }
            };

            var response = ImpostoCondicionalResponseMock.ResponseMock("ikcv");

            _repository.Setup(x => x.GetImpostoCondicional(request)).Returns(response);

            var result = await _useCase.Execute(request);

            result.Should().NotBeNull();
            result.NomeImposto.Should().Be("ikcv");
            result.TaxaImposto.Should().Be(0.06m);
            result.ValorComImpostoDeduzido.Should().Be(235m);
        }

        [Fact]
        public async void ExecuteIcpp_ValorMaiorQue500_ImpostoMaximo_Sucesso()
        {
            var request = new ImpostoCondicionalRequest()
            {
                Imposto = "icpp",
                Itens = new List<ItemImpostoCondicional>
                {
                    new ItemImpostoCondicional()
                    {
                        NomeProduto = "xyz",
                        ValorProduto = 250m
                    },
                    new ItemImpostoCondicional()
                    {
                        NomeProduto = "xyz",
                        ValorProduto = 250m
                    }
                }
            };

            var response = ImpostoCondicionalResponseMock.ResponseMock("icpp");

            _repository.Setup(x => x.GetImpostoCondicional(request)).Returns(response);

            var result = await _useCase.Execute(request);

            result.Should().NotBeNull();
            result.NomeImposto.Should().Be("icpp");
            result.TaxaImposto.Should().Be(0.07m);
            result.ValorComImpostoDeduzido.Should().Be(465m);
        }

        [Fact]
        public async void ExecuteIcpp_ValorMenorQue500_ImpostoMinimo_Sucesso()
        {
            var request = new ImpostoCondicionalRequest()
            {
                Imposto = "icpp",
                Itens = new List<ItemImpostoCondicional>
                {
                    new ItemImpostoCondicional()
                    {
                        NomeProduto = "xyz",
                        ValorProduto = 250m
                    }
                }
            };

            var response = ImpostoCondicionalResponseMock.ResponseMock("icpp");

            _repository.Setup(x => x.GetImpostoCondicional(request)).Returns(response);

            var result = await _useCase.Execute(request);

            result.Should().NotBeNull();
            result.NomeImposto.Should().Be("icpp");
            result.TaxaImposto.Should().Be(0.05m);
            result.ValorComImpostoDeduzido.Should().Be(237.50m);
        }
    }
}
