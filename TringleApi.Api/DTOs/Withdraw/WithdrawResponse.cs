using TringleApi.Api.DTOs.Account;

namespace TringleApi.Api.DTOs.Withdraw
{
    public class WithdrawResponse
    {
        public AccountResponse Account { get; set; }
        public decimal Amount { get; set; }
    }
}
