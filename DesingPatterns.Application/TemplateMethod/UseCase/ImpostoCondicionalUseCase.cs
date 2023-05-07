using DesingPatterns.Application.TemplateMethod.Calculador;
using DesingPatterns.Application.TemplateMethod.Model;
using DesingPatterns.Application.TemplateMethod.Repositories;
using DesingPatterns.Application.TemplateMethod.UseCase.Interface;
using DesingPatterns.Domain.TemplateMethod.DescontoCondicional;

namespace DesingPatterns.Application.TemplateMethod.UseCase
{
    public class ImpostoCondicionalUseCase : IImpostoCondicionalUseCase
    {
        private readonly IImpostoCondicionalRepository _impostoCondicionalRepository;

        public ImpostoCondicionalUseCase(IImpostoCondicionalRepository impostoCondicionalRepository)
        {
            _impostoCondicionalRepository = impostoCondicionalRepository;
        }

        public async Task<ImpostoCondicionalResponse> Execute(ImpostoCondicionalRequest request)
        {
            var respository = await _impostoCondicionalRepository.GetImpostoCondicional(request);
            var timpoImposto = TipoImposto(request.Imposto);

            if (timpoImposto is null) return null;

            var entity = await timpoImposto.Calcular(request, respository);

            return new ImpostoCondicionalResponse()
            {
                NomeImposto = entity.NomeImposto,
                ValorComImpostoDeduzido = entity.Valor,
                TaxaImposto = entity.TaxaImpostoUltilizado
            };
        }

        private static TemplateImpostoCondicional TipoImposto(string imposto)
        {
            if (imposto.Equals(ConstanteImpostoCondicional.ICPP))
            {
                return  new ICPP();
            }
            if (imposto.Equals(ConstanteImpostoCondicional.IKCV))
            {
                return new ICPP();
            }

            return null;
        }
    }
}
