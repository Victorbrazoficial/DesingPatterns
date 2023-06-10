using DesingPatterns.Application.Decorator.Impostos;
using DesingPatterns.Application.Decorator.Impostos.Decorator;
using DesingPatterns.Application.Decorator.Impostos.Decorator.Interfaces;
using DesingPatterns.Application.Decorator.Model.Imposto;
using DesingPatterns.Application.Decorator.Repositories;
using DesingPatterns.Application.Decorator.UseCase.Interface;
using DesingPatterns.Domain.Decorator.Constante;
using DesingPatterns.Domain.Decorator.Imposto;

namespace DesingPatterns.Application.Decorator.UseCase
{
    public class DecoratorUseCase : IDecoratorUseCase
    {
        private readonly IDecoratorRepository _decoratorRepository;

        public DecoratorUseCase(IDecoratorRepository decoratorRepository)
        {
            _decoratorRepository = decoratorRepository;
        }

        public async Task<DecoratorResponse> Execute(DecoratorRequest request)
        {
            var repository =  _decoratorRepository.GetTaxaImposto(request);
            var imposto = GerenciaImposto(request, repository);
            var result = imposto.SomaImposto();

            var response = new DecoratorResponse()
            {
                TaxaImposto = result,
                NomeImposto = BuscaNomeImpostos(repository) 
            };

            return  response;
        }

        private IImpostoBase GerenciaImposto(DecoratorRequest request, List<ImpostoDecoratorEntity> repository)
        {
            IImpostoBase imposto = new ImpostoBase();

            foreach (var item in request.Imposto)
            {
                if (item.Equals(ImpostosDecoratorConstantes.ISS))
                {
                    var iss = repository.Where(x => x.NomeImposto.Equals(ImpostosDecoratorConstantes.ISS));
                    imposto = new IssDecorator(imposto)
                    {
                        TaxaImposto = iss.FirstOrDefault().TaxaImposto
                    };
                }
                if (item.Equals(ImpostosDecoratorConstantes.ICMS))
                {
                    var icms = repository.Where(x => x.NomeImposto.Equals(ImpostosDecoratorConstantes.ICMS));
                    imposto = new IcmsDecorator(imposto)
                    {
                        TaxaImposto = icms.FirstOrDefault().TaxaImposto
                    };
                }
            }

            return imposto;
        }

        private List<string> BuscaNomeImpostos(List<ImpostoDecoratorEntity> listaRepository)
        {
            var listaNomes = new List<string>();

            foreach (var nome in listaRepository.Select(x => x.NomeImposto))
            {
                if (!listaNomes.Contains(ImpostosDecoratorConstantes.ISS) || !listaNomes.Contains(ImpostosDecoratorConstantes.ICMS))
                {
                    listaNomes.Add(nome);
                }
            }

            return listaNomes;
        }
    }
}
