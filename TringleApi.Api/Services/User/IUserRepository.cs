using TringleApi.Api.Services.Repository;
using E = TringleApi.Api.Data.Entities;

namespace TringleApi.Api.Services.User
{
    public interface IUserRepository : IRepository<E.User>
    {
    }
}
