namespace TringleApi.Api.DTOs.Withdraw
{
    public class WithdrawRequest
    {
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
