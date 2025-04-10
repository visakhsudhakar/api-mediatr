using System.Threading.Tasks;
using System.Threading;
using MediatR;
using ApiMediatr.Core.Application.Interfaces;
using ApiMediatr.Core.Domain.Entities;
using ApiMediatr.Core.Application.Commands;

namespace ApiMediatr.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email) { Id = request.Id };
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}