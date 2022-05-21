using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Api.Data.Context;
using TringleApi.Api.Data.Entities;
using TringleApi.Api.DTOs.Deposit;
using TringleApi.Api.Services.Account;
using TringleApi.Api.Services.Deposit;
using TringleApi.Api.WebApiResponse;
using TringleApi.Common.Enums;

namespace TringleApi.Api.Controllers
{
    [ApiController]
    [Route("deposit")]
    public class DepositController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDepositRepository _depositRepository;
        private readonly IAccountRepository _accountRepository;
        public DepositController(IMapper mapper, IDepositRepository depositRepository, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _depositRepository = depositRepository;
            _accountRepository = accountRepository;
        }
        [HttpPost]
        public async Task<ActionResult<WebApiResponse<DepositResponse>>> PostDeposit(DepositRequest request)
        {
            if (ModelState.IsValid)
            {
                var depositingAccount = await _accountRepository.FindAccount(request.AccountNumber);
                try
                {
                    if (depositingAccount == null)
                    {
                        return NotFound(new WebApiResponse<DepositResponse>(false, "Wrong Account Number"));
                    }

                    if (depositingAccount.AccountType == AccountType.Individual)
                    {
                        var deposit = _mapper.Map<Deposit>(request);
                        deposit.Account = depositingAccount;
                        await _accountRepository.Deposit(request.AccountNumber,request.Amount);
                        var insertResult = await _depositRepository.Add(deposit);
                        if (insertResult != null)
                        {
                            return Ok(new WebApiResponse<DepositResponse>(true, "Succes", _mapper.Map<DepositResponse>(deposit)));
                        }
                    }
                    return BadRequest(new WebApiResponse<DepositResponse>(false, "Only individual accounts can deposit"));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return BadRequest(new WebApiResponse<DepositResponse>(false, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList().ToString()));
        }
    }
}
