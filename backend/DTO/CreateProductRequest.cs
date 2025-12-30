namespace Desafio_Lynx.Dtos
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int PriceCents { get; set; }
        public bool Active { get; set; }
    }
}
