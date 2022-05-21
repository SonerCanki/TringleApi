using TringleApi.Api.DTOs.User;
using TringleApi.Common.Enums;

namespace TringleApi.Api.DTOs.Account
{
    public class AccountResponse
    {
        public UserResponse User { get; set; }
        public int AccountNumber { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public string UserName { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Balance { get; set; }
    }
}
