using TringleApi.Api.DTOs.Account;

namespace TringleApi.Api.DTOs.Deposit
{
    public class DepositResponse
    {
        public AccountResponse Account { get; set; }
        public decimal Amount { get; set; }
    }
}
