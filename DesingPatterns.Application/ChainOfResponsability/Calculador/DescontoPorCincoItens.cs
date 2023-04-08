using DesingPatterns.Application.ChainOfResponsability.Calculador.Interface;
using DesingPatterns.Application.ChainOfResponsability.Model;
using DesingPatterns.Application.ChainOfResponsability.Repositories;
using DesingPatterns.Domain.ChainOfResponsability.Desconto;

namespace DesingPatterns.Application.ChainOfResponsability.Calculador
{
    public class DescontoPorCincoItens : IDesconto
    {
        private readonly ITaxaDescontoRepository _taxaDescontoRepository;
        public IDesconto Proximo { get; set; }

        public DescontoPorCincoItens(ITaxaDescontoRepository taxaDescontoRepository)
        {
            _taxaDescontoRepository = taxaDescontoRepository;
        }

        public async Task<DescontoEntity> Desconta(DescontoRequest request)
        {
            var descontoEntity = await _taxaDescontoRepository.GetDescontoPorCincoItens(request);

            foreach (var item in request.Itens)
            {
                descontoEntity.Valor += item.ValorProduto;
            }

            var calculoDesconto = CalculaDesconto(descontoEntity);

            if (descontoEntity.Itens.Count > 5)
            {
                return new DescontoEntity()
                {
                    Valor = calculoDesconto,
                    Texto = "Você atingiu mais de cinco itens por isso recebeu um desconto de 0.1% em relção ao valor total."
                };
            }
            else
            {
                return Proximo.Desconta(request).Result;
            }
        }

        private decimal CalculaDesconto(DescontoEntity descontoEntity)
        {
            var calculoTaxa = descontoEntity.Valor * descontoEntity.TaxaDescotno;
            return calculoTaxa;
        }
    }
}
