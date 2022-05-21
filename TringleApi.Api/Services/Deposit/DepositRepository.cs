using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Api.Data.Context;
using TringleApi.Api.Services.Repository;
using E = TringleApi.Api.Data.Entities;
namespace TringleApi.Api.Services.Deposit
{
    public class DepositRepository : Repository<E.Deposit>, IDepositRepository
    {
        private readonly DataContext _dataContext;
        public DepositRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
