csharp
using ApiMediatr.Core.Application.Interfaces;
using ApiMediatr.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiMediatr.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> GetUsersAsync()
        {
            // Sample data
            return new List<User>
            {
                new User("John Doe", "john.doe@example.com") { Id = 1 },
                new User("Jane Smith", "jane.smith@example.com") { Id = 2 },
                new User("Peter Jones", "peter.jones@example.com") { Id = 3 }
            };
        }
    }
}