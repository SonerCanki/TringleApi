using TringleApi.Api.DTOs.Account;

namespace TringleApi.Api.DTOs.Payment
{
    public class PaymentResponse
    {
        public decimal Amount { get; set; }
        public AccountResponse SenderAccount { get; set; }
        public AccountResponse ReciverAccount { get; set; }
    }
}
