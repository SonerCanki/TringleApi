using TringleApi.Api.Services.Repository;
using E = TringleApi.Api.Data.Entities;

namespace TringleApi.Api.Services.Payment
{
    public interface IPaymentRepository : IRepository<E.Payment>
    {
    }
}
