using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TringleApi.Api.Data.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }

        public Guid SenderAccountId { get; set; }
        public Account SenderAccount { get; set; }
        public Guid ReceiverAccountId { get; set; }
        public Account ReciverAccount { get; set; }

        //public int SenderAccountNumber { get; set; }
        //public int ReciverAccountNumber { get; set; }

        public decimal Amount { get; set; }

    }
}
