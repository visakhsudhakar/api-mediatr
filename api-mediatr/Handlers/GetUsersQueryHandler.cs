using ApiMediatr.Core.Application.Interfaces;
using ApiMediatr.Core.Application.Queries;
using ApiMediatr.Core.Domain.Entities; // Make sure this using statement is present
using MediatR;

namespace ApiMediatr.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            // Access IUserRepository from IUnitOfWork
            return await _unitOfWork.UserRepository.GetUsersAsync();
        }
    }
}