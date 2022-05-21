using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Api.Data.Context;
using TringleApi.Api.DTOs.TransactionHistory;
using TringleApi.Api.Services.Account;
using TringleApi.Api.WebApiResponse;

namespace TringleApi.Api.Controllers
{
    [ApiController]
    [Route("accounting")]
    public class AccountingController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountingController(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        [HttpGet("{accountNumber}")]
        public async Task<ActionResult<WebApiResponse<TransactionHistoryResponse>>> GetTransactions(int accountNumber)
        {
            var account = await _accountRepository.GetByDefault(x => x.AccountNumber == accountNumber, d => d.Deposits, d => d.Withdraws, p => p.SenderPayments);
            if (account != null)
            {
                return Ok(new WebApiResponse<TransactionHistoryResponse>(true, "Succes", _mapper.Map<TransactionHistoryResponse>(account)));
            }
            return NotFound(new WebApiResponse<TransactionHistoryResponse>(false, "There is not Transaction History"));

        }
    }
}
