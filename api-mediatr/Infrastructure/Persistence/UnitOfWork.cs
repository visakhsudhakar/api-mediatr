using ApiMediatr.Infrastructure.Persistence;
using ApiMediatr.Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore.Storage; 
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiMediatr.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private IUserRepository _userRepository;
        private IDbContextTransaction? _transaction;

        

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _transaction?.CommitAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }

        public UnitOfWork(AppDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public IUserRepository UserRepository => _userRepository;
    }
}