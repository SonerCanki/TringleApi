using System;
using TringleApi.Common.Enums;

namespace TringleApi.Api.DTOs.Account
{
    public class AccountRequest
    {
        public Guid UserId { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public AccountType AccountType { get; set; }
    }
}
