csharp
using MediatR;
using ApiMediatr.Core.Application.Queries;
using ApiMediatr.Core.Application.Interfaces;
using ApiMediatr.Core.Domain.Entities;

namespace ApiMediatr.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}