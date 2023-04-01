using System.Text.Json.Serialization;

namespace DesingPatterns.Application.Strategy.Model.Imposto.ICMS
{
    public class ObterImpostoDeduzidoResponse
    {
        [JsonPropertyName("nome_imposto")]
        public string? NomeImposto { get; set; }
        [JsonPropertyName("valor_com_imposto_deduzido")]
        public decimal ValorComImpostoDeduzido { get; set; }
        [JsonPropertyName("taxa_Imposto")]
        public decimal taxaImposto { get; set; }
    }
}
