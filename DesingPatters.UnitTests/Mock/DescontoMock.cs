using DesingPatterns.Application.ChainOfResponsability.Model;
using DesingPatterns.Domain.ChainOfResponsability.Desconto;
using Item = DesingPatterns.Domain.ChainOfResponsability.Desconto.Item;

namespace DesingPatters.UnitTests.Mock
{
    public static class DescontoMock
    {
        public static async Task<DescontoEntity> DescontoResponse(DescontoRequest request)
        {
            const decimal taxaDesconto = 0.1m;

            var response = new DescontoEntity()
            {
                TaxaDescotno = taxaDesconto,
                Texto = "Você atingiu mais de cinco itens por isso recebeu um desconto de 0.1% em relção ao valor total.",
                Valor = 0.0m,               
            };

            response.Valor = CalculaDesconto(response, request);

            return response;
        }

        public static async Task<DescontoEntity> SemDescontoResponse()
        {
            var response = new DescontoEntity()
            {
                Texto = "Se você atingir a quantidade de seis itens você recebera um desconto.",
                Valor = 0.0m,
            };

            return response;
        }

        private static decimal CalculaDesconto(DescontoEntity descontoEntity, DescontoRequest request)
        {
            foreach (var item in request.Itens)
            {
                descontoEntity.Valor += item.ValorProduto;
            }
            var calculoTaxa = descontoEntity.Valor * descontoEntity.TaxaDescotno;
            return calculoTaxa;
        }
    }
}
