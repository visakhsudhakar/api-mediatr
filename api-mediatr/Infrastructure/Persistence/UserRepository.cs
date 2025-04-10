using ApiMediatr.Core.Application.Interfaces;
using ApiMediatr.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ApiMediatr.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        public Task<List<User>> GetUsersAsync()
        {
            // Sample data
            var users = new List<User>
            {
                new User("John Doe", "john.doe@example.com") { Id = 1 },
                new User("Jane Smith", "jane.smith@example.com") { Id = 2 },
                new User("Peter Jones", "peter.jones@example.com") { Id = 3 }
            };
            return Task.FromResult(users);
        }


        public Task Update(User user)
        {
            // Update logic
            return Task.CompletedTask;
        }

        public Task Add(User user)
        {
            //Add Logic
            return Task.CompletedTask;
        }
    }
}