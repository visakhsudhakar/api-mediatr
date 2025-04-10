using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApiMediatr.Core.Application.Interfaces;
using ApiMediatr.Core.Domain.Entities;
using System.Linq;

namespace ApiMediatr.Handlers
{
    public class GetUserQuery : IRequest<List<User>>
    {
    }

    public class GetUserHandler : IRequestHandler<GetUserQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersAsync();
            return users.ToList();
        }
    }

}