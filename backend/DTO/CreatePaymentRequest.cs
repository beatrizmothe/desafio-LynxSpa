namespace Desafio_Lynx.Dtos
{
    public class CreatePaymentRequest
    {
        public int Order_Id { get; set; }
        public int Amount_Cents { get; set; }
        public string Payment_Method { get; set; } = null!;
    }
}
