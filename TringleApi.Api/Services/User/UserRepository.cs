using TringleApi.Api.Data.Context;
using TringleApi.Api.Services.Repository;
using E = TringleApi.Api.Data.Entities;

namespace TringleApi.Api.Services.User
{
    public class UserRepository:Repository<E.User> ,IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
