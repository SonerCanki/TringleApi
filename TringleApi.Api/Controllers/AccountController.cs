using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Api.Data.Entities;
using TringleApi.Api.DTOs.Account;
using TringleApi.Api.Services.Account;
using TringleApi.Api.WebApiResponse;

namespace TringleApi.Api.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        public AccountController(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<AccountResponse>>> PostAccount(AccountRequest request)
        {
            if (ModelState.IsValid)
            {
                var account = _mapper.Map<Account>(request);
                var accountNumber = await _accountRepository.CreateAccountNumber();
                if (await _accountRepository.CheckAccountNumber(accountNumber))
                {
                    account.AccountNumber = accountNumber;
                }
                var insertResult = await _accountRepository.Add(account);
                if (insertResult != null)
                {
                    return Ok(new WebApiResponse<AccountResponse>(true, "Succes", _mapper.Map<AccountResponse>(account)));
                }
            }
            return BadRequest(new WebApiResponse<AccountResponse>(false, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList().ToString()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<AccountResponse>>> GetAccount(Guid id)
        {
            var account = await _accountRepository.GetByDefault(x => x.Id == id);
            if (account != null)
            {
                return Ok(new WebApiResponse<AccountResponse>(true, "Succes", _mapper.Map<AccountResponse>(account)));
            }
            return NotFound(new WebApiResponse<AccountResponse>(false, "There is not a account has a this id"));
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<Account>>>> GetAccounts()
        {
            var accounts = await _accountRepository.GetAll();
            if (accounts != null)
            {
                return Ok(new WebApiResponse<List<Account>>(true, "Succes", accounts));
            }
            return NotFound(new WebApiResponse<List<Account>>(false, "Error"));

        }
    }
}
