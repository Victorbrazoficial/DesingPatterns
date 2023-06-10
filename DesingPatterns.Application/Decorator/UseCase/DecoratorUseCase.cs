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
            var imposto = GerenciaImposto(request);
            var repository = _decoratorRepository.GetTaxaImposto(request);
            var result = SomaDosImpostos(repository, imposto);

            var response = new DecoratorResponse()
            {
                TaxaImposto = result,
                NomeImposto = BuscaNomeImpsotos(repository)
                
            };

            return response;
        }

        private IImpostoBase GerenciaImposto(DecoratorRequest request)
        {
            IImpostoBase imposto = new ImpostoBase();

            foreach (var item in request.Imposto)
            {
                if (item.Equals(ImpostosDecoratorConstantes.ISS))
                {
                    imposto = new IssDecorator(imposto);
                }
                if (item.Equals(ImpostosDecoratorConstantes.ICMS))
                {
                    imposto = new IcmsDecorator(imposto);
                }
            }

            return imposto;
        }

        private decimal SomaDosImpostos(List<ImpostoDecoratorEntity> repository, IImpostoBase imposto)
        {
            var icms = repository.Where(x => x.NomeImposto.Equals(ImpostosDecoratorConstantes.ICMS));
            var iss = repository.Where(x => x.NomeImposto.Equals(ImpostosDecoratorConstantes.ISS));
            decimal result = 0;

            if (icms.Any())
            {
                result = imposto.SomaImposto(icms.FirstOrDefault().TaxaImposto);
            }
            if (iss.Any())
            {
                result = imposto.SomaImposto(iss.FirstOrDefault().TaxaImposto);
            }

            return result;
        }

        private List<string> BuscaNomeImpsotos(List<ImpostoDecoratorEntity> listaRepository)
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
