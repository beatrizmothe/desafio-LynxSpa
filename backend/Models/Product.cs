using System.Text.Json.Serialization;

namespace Desafio_Lynx.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;

        [JsonPropertyName("priceCents")]
        public int PriceCents { get; set; }

        public bool Active { get; set; } = true;
    }
}
