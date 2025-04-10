
using MediatR;

namespace ApiMediatr.Core.Application.Commands
{    
    public class AddUserCommand : IRequest<Unit>
    {        
        
        public string Name { get; set; }
        public string Email { get; set; }

        public AddUserCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}