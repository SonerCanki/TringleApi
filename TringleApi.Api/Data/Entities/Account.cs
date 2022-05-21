using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Common.Enums;

namespace TringleApi.Api.Data.Entities
{
    public class Account
    {
        public Account()
        {
            Withdraws = new HashSet<Withdraw>();
            Deposits = new HashSet<Deposit>();
            SenderPayments = new HashSet<Payment>();
            ReciverPayments = new HashSet<Payment>();
        }
        public Guid Id { get; set; }
        public int AccountNumber { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Balance { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }


        public ICollection<Deposit> Deposits { get; set; }
        public ICollection<Withdraw> Withdraws { get; set; }
        public ICollection<Payment> SenderPayments { get; set; }
        public ICollection<Payment> ReciverPayments { get; set; }

    }
}
