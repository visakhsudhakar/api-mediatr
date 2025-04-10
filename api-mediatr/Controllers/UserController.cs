csharp
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApiMediatr.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            var result = await _mediator.Send(new GetUsersRequest(), cancellationToken);
            return Ok(result);
        }
    }

    public class GetUsersRequest : IRequest<List<string>>
    {
    }
    
    public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, List<string>>
    {
        public async Task<List<string>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            return new List<string> { "User1", "User2", "User3" };
        }
    }
}