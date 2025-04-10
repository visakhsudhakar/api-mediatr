
using System.Threading.Tasks;

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