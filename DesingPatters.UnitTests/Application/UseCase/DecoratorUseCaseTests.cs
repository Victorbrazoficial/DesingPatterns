using DesingPatterns.Application.Decorator.Model.Imposto;
using DesingPatterns.Application.Decorator.Repositories;
using DesingPatterns.Application.Decorator.UseCase;
using DesingPatterns.Domain.Decorator.Constante;
using DesingPatterns.Domain.Decorator.Imposto;
using FluentAssertions;
using Moq;

namespace DesingPatters.UnitTests.Application.UseCase
{
    public class DecoratorUseCaseTests
    {
        private readonly Mock<IDecoratorRepository> _decoratorRepository;

        public DecoratorUseCaseTests()
        {
            _decoratorRepository = new Mock<IDecoratorRepository>();
        }

        [Fact]
        public async void SomaDeDoisImpostos_DeveRetornar_sucesso()
        {
            var request = new DecoratorRequest()
            {
                Imposto = new List<string>()
                {
                    "icms",
                    "iss"
                },
                Valor = 1
            };

            var response = new DecoratorResponse()
            {
                TaxaImposto = 14
            };

            _decoratorRepository.Setup(x => x.GetTaxaImposto(request)).Returns(DecoratorReositoryMock.GetTaxaImposto);

            var useCase = new DecoratorUseCase(_decoratorRepository.Object);
            var result = await useCase.Execute(request);

            useCase.Should().NotBeNull();
            Assert.Equal(result.TaxaImposto, response.TaxaImposto);
        }

        [Fact]
        public async void SomaDeTres_DeveRetornar_Impostos()
        {
            var request = new DecoratorRequest()
            {
                Imposto = new List<string>()
                {
                    "icms",
                    "iss",
                    "iss"
                },
                Valor = 1
            };

            var response = new DecoratorResponse()
            {
                TaxaImposto = 16
            };

            _decoratorRepository.Setup(x => x.GetTaxaImposto(request)).Returns(DecoratorReositoryMock.GetTaxaImposto);

            var useCase = new DecoratorUseCase(_decoratorRepository.Object);
            var result = await useCase.Execute(request);

            useCase.Should().NotBeNull();
            Assert.Equal(result.TaxaImposto, response.TaxaImposto);
        }
    }

    public static class DecoratorReositoryMock
    {
        private const decimal TaxaICMS = 12M;
        private const decimal TaxaISS = 2M;

        public static List<ImpostoDecoratorEntity> GetTaxaImposto(DecoratorRequest request)
        {
            var listaEntity = new List<ImpostoDecoratorEntity>();


            foreach (var imposto in request.Imposto)
            {
                if (imposto.Equals(ImpostosDecoratorConstantes.ISS))
                {
                    var entity = new ImpostoDecoratorEntity()
                    {
                        NomeImposto = ImpostosDecoratorConstantes.ISS,
                        TaxaImposto = TaxaISS

                    };
                    listaEntity.Add(entity);
                }
                else if (imposto.Equals(ImpostosDecoratorConstantes.ICMS))
                {
                    var entity = new ImpostoDecoratorEntity()
                    {
                        NomeImposto = ImpostosDecoratorConstantes.ICMS,
                        TaxaImposto = TaxaICMS
                    };
                    listaEntity.Add(entity);
                }
                else
                {
                    throw new Exception($"o imposto [{imposto}] não existe");
                }
            }

            return listaEntity;
        }
    }
}
