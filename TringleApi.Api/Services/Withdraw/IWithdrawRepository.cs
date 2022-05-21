using TringleApi.Api.Services.Repository;
using E = TringleApi.Api.Data.Entities;

namespace TringleApi.Api.Services.Withdraw
{
    public interface IWithdrawRepository : IRepository<E.Withdraw>
    {
    }
}
