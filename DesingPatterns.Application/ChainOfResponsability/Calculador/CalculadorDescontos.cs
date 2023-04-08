using DesingPatterns.Application.ChainOfResponsability.Calculador.Interface;
using DesingPatterns.Application.ChainOfResponsability.Model;
using DesingPatterns.Application.ChainOfResponsability.Repositories;
using DesingPatterns.Domain.ChainOfResponsability.Desconto;

namespace DesingPatterns.Application.ChainOfResponsability.Calculador
{
    public class CalculadorDescontos : ICalculadorDescontos
    {
        private readonly ITaxaDescontoRepository _taxaDescontoRepository;

        public CalculadorDescontos(ITaxaDescontoRepository taxaDescontoRepository)
        {
            _taxaDescontoRepository = taxaDescontoRepository;
        }

        public Task<DescontoEntity> Desconta(DescontoRequest request)
        {
            IDesconto descontoPorCincoItens = new DescontoPorCincoItens( _taxaDescontoRepository);
            IDesconto semDesconto = new SemDesconto();

            descontoPorCincoItens.Proximo = semDesconto;
            
            return descontoPorCincoItens.Desconta(request);
        }
    }
}
