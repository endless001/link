using Identity.Administration.Infrastructure.Exceptions;

namespace Identity.Administration.Infrastructure.Resources;

public class ApiErrorResources:IApiErrorResources
{
    public ApiError CannotSetId()
    {
        return new ApiError
        {
            Code = nameof(CannotSetId),
            Description = ApiErrorResource.CannotSetId
        };
    }
}