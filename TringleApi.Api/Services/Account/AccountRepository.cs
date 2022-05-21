using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TringleApi.Api.Data.Context;
using TringleApi.Api.Data.Entities;
using TringleApi.Api.Services.Repository;
using E = TringleApi.Api.Data.Entities;

namespace TringleApi.Api.Services.Account
{
    public class AccountRepository : Repository<E.Account>, IAccountRepository
    {
        private readonly DataContext _dataContext;
        public AccountRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public async Task<E.Account> FindAccount(int accountnumber)
        {
            return await _dataContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == accountnumber);
        }

        public async Task<bool> CheckAccountNumber(int accountNumber)
        {
            if (await _dataContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == accountNumber) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<int> CreateAccountNumber()
        {
            Random random = new Random();

            string AccountNumber = "";

            for (int i = 0; i < 8; i++)
            {
                AccountNumber += random.Next(0, 10);
            }

            return Convert.ToInt32(AccountNumber);
        }

        public async Task<bool> Payment(int senderAccountNumber, int reciverAccountNumber, decimal amount)
        {
            try
            {
                var senderAccount = await FindAccount(senderAccountNumber);
                var reciverAccount = await FindAccount(reciverAccountNumber);
                senderAccount.Balance -= amount;
                reciverAccount.Balance += amount;
                _dataContext.Accounts.Update(senderAccount);
                _dataContext.Accounts.Update(reciverAccount);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Deposit(int accountNumber, decimal amount)
        {
            try
            {
                var account = await FindAccount(accountNumber);
                account.Balance += amount;
                _dataContext.Accounts.Update(account);

                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Withdraw(int accountNumber, decimal amount)
        {
            try
            {
                var account = await FindAccount(accountNumber);
                account.Balance -= amount;
                _dataContext.Accounts.Update(account);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
