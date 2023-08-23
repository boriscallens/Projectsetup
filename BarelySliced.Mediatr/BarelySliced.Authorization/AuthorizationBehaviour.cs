using MediatR;

namespace BarelySliced.Authorization;

public class AuthorizationBehaviour<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public AuthorizationBehaviour()
    {
        
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // TODO: how to get the Principal here?
        IEnumerable<IAuthorizer<TRequest>> authorizers = null;
        authorizers.Aggregate(AuthorizationResult.Success, (result, authorizer) =>
        {
            var authorizationResult = authorizer.Authorize(request, principal);
            return result.Merge(authorizationResult);
        });
    }
}
