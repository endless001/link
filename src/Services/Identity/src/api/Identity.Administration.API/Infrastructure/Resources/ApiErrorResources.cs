using Identity.Administration.API.Infrastructure.Exceptions;

namespace Identity.Administration.API.Infrastructure.Resources;

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