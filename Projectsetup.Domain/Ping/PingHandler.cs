﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Projectsetup.Domain.Ping
{
    public class PingHandler : IRequestHandler<PingRequest, PingResult>
    {
        public Task<PingResult> Handle(PingRequest request, CancellationToken cancellationToken)
        {
            var pingResult = new PingResult(request);
            return Task.FromResult(pingResult);
        }
    }
}
