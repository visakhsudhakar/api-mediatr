using ApiMediatr.Core.Application.Commands;
using ApiMediatr.Core.Application.Interfaces;
using ApiMediatr.Core.Domain.Entities;
using MediatR;
using System.Threading;

namespace ApiMediatr.Handlers
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email);
            _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync(); // Add await here
            return Unit.Value;
        }
    }
}