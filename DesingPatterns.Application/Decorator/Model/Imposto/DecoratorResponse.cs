using System.Text.Json.Serialization;

namespace DesingPatterns.Application.Decorator.Model.Imposto
{
    public class DecoratorResponse
    {
        [JsonPropertyName("nome_imposto")]
        public List<string>? NomeImposto { get; set; }
        
        [JsonPropertyName("taxa_imposto")]
        public decimal TaxaImposto { get; set; }
    }
}
