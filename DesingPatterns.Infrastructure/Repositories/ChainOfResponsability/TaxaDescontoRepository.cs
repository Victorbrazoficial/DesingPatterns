using DesingPatterns.Application.ChainOfResponsability.Model;
using DesingPatterns.Application.ChainOfResponsability.Repositories;
using DesingPatterns.Domain.ChainOfResponsability.Desconto;
using Item = DesingPatterns.Domain.ChainOfResponsability.Desconto.Item;

namespace DesingPatterns.Infrastructure.Repositories.ChainOfResponsability
{
    public class TaxaDescontoRepository : ITaxaDescontoRepository
    {
        private const decimal TaxaDescontoPorCincoItens = 0.1m;
        public async Task<DescontoEntity> GetDescontoPorCincoItens(DescontoRequest request)
        {
            var descontoEntity = AddItem(request);

            descontoEntity.TaxaDescotno = TaxaDescontoPorCincoItens;

            return descontoEntity;
        }

        private DescontoEntity AddItem(DescontoRequest request)
        {
            var descontoEntity = new DescontoEntity()
            {
                Itens = new List<Item>()
            };

            foreach (var item in request.Itens)
            {
                descontoEntity.Itens.Add(
                    new Item() 
                    { 
                        Nome = item.NomeProduto,
                        Valor = item.ValorProduto 
                    });
            }

            return descontoEntity;
        }
    }
}
