using System;
using System.Collections.Generic;
using TringleApi.Api.DTOs.Account;

namespace TringleApi.Api.DTOs.User
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<AccountResponse> Accounts { get; set; }
    }
}
