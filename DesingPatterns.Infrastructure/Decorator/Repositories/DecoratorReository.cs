using DesingPatterns.Application.Decorator.Model.Imposto;
using DesingPatterns.Application.Decorator.Repositories;
using DesingPatterns.Domain.Decorator.Constante;
using DesingPatterns.Domain.Decorator.Imposto;

namespace DesingPatterns.Infrastructure.Decorator.Repositories
{
    public class DecoratorReository : IDecoratorRepository
    {
        private const decimal TaxaICMS = 12M;
        private const decimal TaxaISS = 2M;

        public List<ImpostoDecoratorEntity> GetTaxaImposto(DecoratorRequest request)
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
