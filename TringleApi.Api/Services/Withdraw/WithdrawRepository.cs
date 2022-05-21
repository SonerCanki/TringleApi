using TringleApi.Api.Data.Context;
using TringleApi.Api.Services.Repository;
using E = TringleApi.Api.Data.Entities;

namespace TringleApi.Api.Services.Withdraw
{
    public class WithdrawRepository : Repository<E.Withdraw>, IWithdrawRepository
    {
        private readonly DataContext _dataContext;
        public WithdrawRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
