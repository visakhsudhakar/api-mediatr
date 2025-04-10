using MediatR;
using Microsoft.AspNetCore.Mvc;
using ApiMediatr.Core.Application.Commands;
using ApiMediatr.Core.Application.Queries;
using System.Threading.Tasks;
using ApiMediatr.Core.Domain.Entities;
using ApiMediatr.Core.Application.Interfaces;

namespace ApiMediatr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetUsersQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user, CancellationToken cancellationToken)
        {
            if (user == null)
            {
                return BadRequest("User data is required.");
            }

            var result = await _mediator.Send(new AddUserCommand(user.Name, user.Email), cancellationToken);

            // Assuming AddUserCommand returns the ID of the newly created user
            return CreatedAtAction(nameof(GetUsers), new { id = result }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user, CancellationToken cancellationToken)
        {
            if (user == null || id != user.Id)
            {
                return BadRequest("Invalid user data or ID mismatch.");
            }

            var result = await _mediator.Send(new UpdateUserCommand(user.Id, user.Name, user.Email), cancellationToken);
            return Ok(result);
        }
    }
}