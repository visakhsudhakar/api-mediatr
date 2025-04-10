using ApiMediatr.Core.Application.Interfaces;
using ApiMediatr.Core.Domain.Entities;
using ApiMediatr.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiMediatr.Infrastructure.Persistence
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;

        public Task<List<User>> GetUsersAsync()
        {
            if (_context.Users == null)
            {
                return Task.FromResult(new List<User>());
            }

            var users = _context.Users.ToList();            
            return Task.FromResult(users);
        }

        public Task Update(User user)
        {
            // Update logic
            _context.Users?.Update(user);
            return Task.CompletedTask;
        }

        public Task Add(User user)
        {
            _context.Users?.Add(user);
            return Task.CompletedTask;
        }
    }
}