using DesingPatterns.Application.ChainOfResponsability.Model;

namespace DesingPatterns.Application.TemplateMethod.Model
{
    public class ImpostoCondicionalRequest
    {
        public string Imposto { get; set; }
        public List<Item> Itens { get; set; }
    }
}
