using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TringleApi.Api.Data.Context;
using TringleApi.Api.Services.Repository;
using E = TringleApi.Api.Data.Entities;
namespace TringleApi.Api.Services.Payment
{
    public class PaymentRepository : Repository<E.Payment>, IPaymentRepository
    {
        private readonly DataContext _dataContext;
        public PaymentRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
