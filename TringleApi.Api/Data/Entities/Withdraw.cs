using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Common.Enums;

namespace TringleApi.Api.Data.Entities
{
    public class Withdraw
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; }
    }
}
