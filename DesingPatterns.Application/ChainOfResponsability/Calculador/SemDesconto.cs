using DesingPatterns.Application.ChainOfResponsability.Calculador.Interface;
using DesingPatterns.Application.ChainOfResponsability.Model;
using DesingPatterns.Domain.ChainOfResponsability.Desconto;

namespace DesingPatterns.Application.ChainOfResponsability.Calculador
{
    public class SemDesconto : IDesconto
    {
        public IDesconto Proximo { get; set; }

        public Task<DescontoEntity> Desconta(DescontoRequest request)
        {
            var response = new DescontoEntity()
            {
                TaxaDescotno = 0m,
                Texto = "Se você atingir a quantidade de seis itens você recebera um desconto."
            };

            return Task.FromResult(response);
        }
    }
}
