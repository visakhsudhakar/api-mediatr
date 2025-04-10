
using System.Threading.Tasks;
using ApiMediatr.Core.Domain.Entities;

namespace ApiMediatr.Core.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IUserRepository UserRepository { get; }
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
    }
}