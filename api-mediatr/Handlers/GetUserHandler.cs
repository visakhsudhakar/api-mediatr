csharp
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApiMediatr.Handlers
{
    public class GetUserQuery : IRequest<List<string>>
    {
    }

    public class GetUserHandler : IRequestHandler<GetUserQuery, List<string>>
    {
        public async Task<List<string>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return new List<string> { "User1", "User2", "User3" };
        }
    }
}