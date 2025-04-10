
using ApiMediatr.Core.Domain.Entities;
using MediatR;

namespace ApiMediatr.Core.Application.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UpdateUserCommand(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}