using ApiMediatr.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiMediatr.Core.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task Update(User user);
        Task Add(User user);
    }
}