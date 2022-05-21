using System.Threading.Tasks;
using TringleApi.Api.Services.Repository;
using E = TringleApi.Api.Data.Entities;

namespace TringleApi.Api.Services.Account
{
    public interface IAccountRepository : IRepository<E.Account>
    {
        Task<E.Account> FindAccount(int accountnumber);
        Task<bool> CheckAccountNumber(int accountNumber);
        Task<int> CreateAccountNumber();
        Task<bool> Payment(int senderAccountNumber, int reciverAccountNumber, decimal amount);
        Task<bool> Deposit(int accountNumber, decimal amount);
        Task<bool> Withdraw(int accountNumber, decimal amount);
    }
}
