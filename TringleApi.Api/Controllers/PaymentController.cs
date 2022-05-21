using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Api.Data.Entities;
using TringleApi.Api.DTOs.Payment;
using TringleApi.Api.Services.Account;
using TringleApi.Api.Services.Payment;
using TringleApi.Api.WebApiResponse;
using TringleApi.Common.Enums;

namespace TringleApi.Api.Controllers
{
    [ApiController]
    [Route("payment")]
    public class PaymentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAccountRepository _accountRepository;
        public PaymentController(IPaymentRepository paymentRepository, IMapper mapper, IAccountRepository accountRepository)
        {
            _paymentRepository = paymentRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<WebApiResponse<PaymentResponse>>> PostPayment(PaymentRequest request)
        {
            if (ModelState.IsValid)
            {
                var reciverAccount = await _accountRepository.FindAccount(request.ReciverAccountNumber);
                var senderAccount = await _accountRepository.FindAccount(request.SenderAccountNumber);
                if (reciverAccount == null && senderAccount == null)
                {
                    return BadRequest(new WebApiResponse<PaymentResponse>(false, "Wrong Account Number"));
                }
                if (senderAccount.AccountType == AccountType.Individual && reciverAccount.AccountType == AccountType.Corporate)
                {
                    var payment = _mapper.Map<Payment>(request);
                    payment.ReciverAccount = reciverAccount;
                    payment.SenderAccount = senderAccount;
                    await _accountRepository.Payment(request.SenderAccountNumber, request.ReciverAccountNumber, request.Amount);
                    var insertResult = await _paymentRepository.Add(payment);
                    if (insertResult != null)
                    {
                        return Ok(new WebApiResponse<PaymentResponse>(true, "Succes", _mapper.Map<PaymentResponse>(payment)));
                    }
                }
                return BadRequest(new WebApiResponse<PaymentResponse>(false, "Payments can be only from invidual account to corporate account"));

            }
            return BadRequest(new WebApiResponse<PaymentResponse>(false, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList().ToString()));
        }
    }
}
//