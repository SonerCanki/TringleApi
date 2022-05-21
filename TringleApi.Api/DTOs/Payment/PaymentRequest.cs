namespace TringleApi.Api.DTOs.Payment
{
    public class PaymentRequest
    {
        public int SenderAccountNumber { get; set; }
        public int ReciverAccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
