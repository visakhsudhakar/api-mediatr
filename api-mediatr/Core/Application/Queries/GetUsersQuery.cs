using ApiMediatr.Core.Domain.Entities;
using MediatR;

namespace ApiMediatr.Core.Application.Queries
{
    public class GetUsersQuery : IRequest<List<User>>
    {
    }
}