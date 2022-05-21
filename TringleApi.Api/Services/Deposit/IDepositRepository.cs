using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Api.Services.Repository;
using E = TringleApi.Api.Data.Entities;

namespace TringleApi.Api.Services.Deposit
{
    public interface IDepositRepository : IRepository<E.Deposit>
    {

    }
}
