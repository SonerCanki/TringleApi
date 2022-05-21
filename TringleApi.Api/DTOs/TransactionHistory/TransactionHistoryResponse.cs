using System;
using System.Collections.Generic;
using TringleApi.Api.DTOs.Deposit;
using TringleApi.Api.DTOs.Payment;
using TringleApi.Api.DTOs.Withdraw;

namespace TringleApi.Api.DTOs.TransactionHistory
{
    public class TransactionHistoryResponse
    {
        public ICollection<DepositResponse> Deposits { get; set; }
        public ICollection<PaymentResponse> SenderPayments { get; set; }
        public  ICollection<WithdrawResponse> Withdraws { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
