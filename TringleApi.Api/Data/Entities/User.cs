using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TringleApi.Api.Data.Entities
{
    public class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
