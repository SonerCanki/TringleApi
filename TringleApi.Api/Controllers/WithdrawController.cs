using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Api.Data.Entities;
using TringleApi.Api.DTOs.Withdraw;
using TringleApi.Api.Services.Account;
using TringleApi.Api.Services.Withdraw;
using TringleApi.Api.WebApiResponse;
using TringleApi.Common.Enums;

namespace TringleApi.Api.Controllers
{
    [ApiController]
    [Route("withdraw")]
    public class WithdrawController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IWithdrawRepository _withdrawRepository;
        private readonly IMapper _mapper;
        public WithdrawController(IMapper mapper, IWithdrawRepository withdrawRepository, IAccountRepository accountRepsoitory)
        {
            _mapper = mapper;
            _withdrawRepository = withdrawRepository;
            _accountRepository = accountRepsoitory;
        }
        [HttpPost]
        public async Task<ActionResult<WebApiResponse<WithdrawResponse>>> PostWithdraw(WithdrawRequest request)
        {
            if (ModelState.IsValid)
            {
                var WithdrawingAccount = await _accountRepository.FindAccount(request.AccountNumber);
                try
                {
                    if (WithdrawingAccount == null)
                    {
                        return NotFound(new WebApiResponse<WithdrawResponse>(false, "Wrong Account Number"));
                    }

                    if (WithdrawingAccount.AccountType == AccountType.Individual)
                    {
                        var withdraw = _mapper.Map<Withdraw>(request);
                        withdraw.Account = WithdrawingAccount;
                        await _accountRepository.Withdraw(request.AccountNumber, request.Amount);
                        var insertResult = await _withdrawRepository.Add(withdraw);
                        if (insertResult != null)
                        {
                            return new WebApiResponse<WithdrawResponse>(true, "Succes", _mapper.Map<WithdrawResponse>(withdraw));
                        }
                    }
                    return BadRequest(new WebApiResponse<WithdrawResponse>(false, "Only individual accounts can withdraw"));
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return BadRequest(new WebApiResponse<WithdrawResponse>(true, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList().ToString()));
        }
    }
}
